﻿#region License

/*



Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.

*/

#endregion

using Amplifier.OpenCL.Cloo.Bindings;

namespace Amplifier.OpenCL.Cloo
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;

    /// <summary>
    /// Represents an OpenCL platform.
    /// </summary>
    /// <remarks> The host plus a collection of devices managed by the OpenCL framework that allow an application to share resources and execute kernels on devices in the platform. </remarks>
    /// <seealso cref="ComputeDevice"/>
    /// <seealso cref="ComputeKernel"/>
    /// <seealso cref="ComputeResource"/>
    internal class ComputePlatform : ComputeObject
    {
        #region Fields

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private ReadOnlyCollection<ComputeDevice> _devices;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly ReadOnlyCollection<string> _extensions;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly string _name;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private static readonly ReadOnlyCollection<ComputePlatform> platforms;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly string _profile;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly string _vendor;

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly string _version;

        #endregion

        #region Properties

        /// <summary>
        /// The handle of the <see cref="ComputePlatform"/>.
        /// </summary>
        public CLPlatformHandle Handle
        {
            get;
            protected set;
        }

        /// <summary>
        /// Gets a read-only collection of <see cref="ComputeDevice"/>s available on the <see cref="ComputePlatform"/>.
        /// </summary>
        /// <value> A read-only collection of <see cref="ComputeDevice"/>s available on the <see cref="ComputePlatform"/>. </value>
        public ReadOnlyCollection<ComputeDevice> Devices => _devices;

        /// <summary>
        /// Gets a read-only collection of extension names supported by the <see cref="ComputePlatform"/>.
        /// </summary>
        /// <value> A read-only collection of extension names supported by the <see cref="ComputePlatform"/>. </value>
        public ReadOnlyCollection<string> Extensions => _extensions;

        /// <summary>
        /// Gets the <see cref="ComputePlatform"/> name.
        /// </summary>
        /// <value> The <see cref="ComputePlatform"/> name. </value>
        public string Name => _name;

        /// <summary>
        /// Gets a read-only collection of available <see cref="ComputePlatform"/>s.
        /// </summary>
        /// <value> A read-only collection of available <see cref="ComputePlatform"/>s. </value>
        /// <remarks> The collection will contain no items, if no OpenCL platforms are found on the system. </remarks>
        public static ReadOnlyCollection<ComputePlatform> Platforms => platforms;

        /// <summary>
        /// Gets the name of the profile supported by the <see cref="ComputePlatform"/>.
        /// </summary>
        /// <value> The name of the profile supported by the <see cref="ComputePlatform"/>. </value>
        public string Profile => _profile;

        /// <summary>
        /// Gets the <see cref="ComputePlatform"/> vendor.
        /// </summary>
        /// <value> The <see cref="ComputePlatform"/> vendor. </value>
        public string Vendor => _vendor;

        /// <summary>
        /// Gets the OpenCL version string supported by the <see cref="ComputePlatform"/>.
        /// </summary>
        /// <value> The OpenCL version string supported by the <see cref="ComputePlatform"/>. It has the following format: <c>OpenCL[space][major_version].[minor_version][space][vendor-specific information]</c>. </value>
        public string Version => _version;

        #endregion

        #region Constructors

        static ComputePlatform()
        {
            lock (typeof(ComputePlatform))
            {
                try
                {
                    if (platforms != null)
                        return;

                    ComputeErrorCode error = CL12.GetPlatformIDs(0, null, out var handlesLength);
                    ComputeException.ThrowOnError(error);
                    var handles = new CLPlatformHandle[handlesLength];

                    error = CL12.GetPlatformIDs(handlesLength, handles, out handlesLength);
                    ComputeException.ThrowOnError(error);

                    List<ComputePlatform> platformList = new List<ComputePlatform>(handlesLength);
                    foreach (CLPlatformHandle handle in handles)
                        platformList.Add(new ComputePlatform(handle));

                    platforms = platformList.AsReadOnly();
                }
                catch (DllNotFoundException)
                {
                    platforms = new List<ComputePlatform>().AsReadOnly();
                }
            }
        }

        private ComputePlatform(CLPlatformHandle handle)
        {
            Handle = handle;
            SetID(Handle.Value);

            string extensionString = GetStringInfo(Handle, ComputePlatformInfo.Extensions, CL12.GetPlatformInfo);
            _extensions = new ReadOnlyCollection<string>(extensionString.Split(new [] { ' ' }, StringSplitOptions.RemoveEmptyEntries));

            _name = GetStringInfo(Handle, ComputePlatformInfo.Name, CL12.GetPlatformInfo);
            _profile = GetStringInfo(Handle, ComputePlatformInfo.Profile, CL12.GetPlatformInfo);
            _vendor = GetStringInfo(Handle, ComputePlatformInfo.Vendor, CL12.GetPlatformInfo);
            _version = GetStringInfo(Handle, ComputePlatformInfo.Version, CL12.GetPlatformInfo);
            QueryDevices();
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Gets a <see cref="ComputePlatform"/> of a specified handle.
        /// </summary>
        /// <param name="handle"> The handle of the queried <see cref="ComputePlatform"/>. </param>
        /// <returns> The <see cref="ComputePlatform"/> of the matching handle or <c>null</c> if none matches. </returns>
        public static ComputePlatform GetByHandle(IntPtr handle)
        {
            foreach (ComputePlatform platform in Platforms)
                if (platform.Handle.Value == handle)
                    return platform;

            return null;
        }

        /// <summary>
        /// Gets the first matching <see cref="ComputePlatform"/> of a specified name.
        /// </summary>
        /// <param name="platformName"> The name of the queried <see cref="ComputePlatform"/>. </param>
        /// <returns> The first <see cref="ComputePlatform"/> of the specified name or <c>null</c> if none matches. </returns>
        public static ComputePlatform GetByName(string platformName)
        {
            foreach (ComputePlatform platform in Platforms)
                if (platform.Name.Equals(platformName))
                    return platform;

            return null;
        }

        /// <summary>
        /// Gets the first matching <see cref="ComputePlatform"/> of a specified vendor.
        /// </summary>
        /// <param name="platformVendor"> The vendor of the queried <see cref="ComputePlatform"/>. </param>
        /// <returns> The first <see cref="ComputePlatform"/> of the specified vendor or <c>null</c> if none matches. </returns>
        public static ComputePlatform GetByVendor(string platformVendor)
        {
            foreach (ComputePlatform platform in Platforms)
                if (platform.Vendor.Equals(platformVendor))
                    return platform;

            return null;
        }

        /// <summary>
        /// Gets a read-only collection of available <see cref="ComputeDevice"/>s on the <see cref="ComputePlatform"/>.
        /// </summary>
        /// <returns> A read-only collection of the available <see cref="ComputeDevice"/>s on the <see cref="ComputePlatform"/>. </returns>
        /// <remarks> This method resets the <c>ComputePlatform.Devices</c>. This is useful if one or more of them become unavailable (<c>ComputeDevice.Available</c> is <c>false</c>) after a <see cref="ComputeContext"/> and <see cref="ComputeCommandQueue"/>s that use the <see cref="ComputeDevice"/> have been created and commands have been queued to them. Further calls will trigger an <c>OutOfResourcesComputeException</c> until this method is executed. You will also need to recreate any <see cref="ComputeResource"/> that was created on the no longer available <see cref="ComputeDevice"/>. </remarks>
        public ReadOnlyCollection<ComputeDevice> QueryDevices()
        {
            ComputeErrorCode error = CL12.GetDeviceIDs(Handle, ComputeDeviceTypes.All, 0, null, out var handlesLength);
            ComputeException.ThrowOnError(error);

            CLDeviceHandle[] handles = new CLDeviceHandle[handlesLength];
            error = CL12.GetDeviceIDs(Handle, ComputeDeviceTypes.All, handlesLength, handles, out handlesLength);
            ComputeException.ThrowOnError(error);

            ComputeDevice[] devices = new ComputeDevice[handlesLength];
            for (int i = 0; i < handlesLength; i++)
                devices[i] = new ComputeDevice(this, handles[i]);

            _devices = new ReadOnlyCollection<ComputeDevice>(devices);

            return _devices;
        }

        #endregion
    }
}