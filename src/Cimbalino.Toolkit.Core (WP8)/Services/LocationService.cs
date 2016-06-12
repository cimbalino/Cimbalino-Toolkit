// ****************************************************************************
// <copyright file="LocationService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Core</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="ILocationService"/>.
    /// </summary>
    public class LocationService : ILocationService
    {
        private readonly Geolocator _geolocator;

        /// <summary>
        /// Occurs when the location service detects a change in position.
        /// </summary>
        public event EventHandler<LocationServicePositionChangedEventArgs> PositionChanged;

        /// <summary>
        /// Occurs when the status of the location service changes.
        /// </summary>
        public event EventHandler<LocationServiceStatusChangedEventArgs> StatusChanged;

        #region Properties

        /// <summary>
        /// Gets the accuracy level at which the location service provides location updates.
        /// </summary>
        /// <value>The accuracy level at which the location service provides location updates.</value>
        public virtual LocationServiceAccuracy DesiredAccuracy
        {
            get
            {
                return _geolocator.DesiredAccuracy.ToLocationServiceAccuracy();
            }
        }

        /// <summary>
        /// Gets the desired accuracy in meters for data returned from the location service.
        /// </summary>
        /// <value>The desired accuracy in meters for data returned from the location service.</value>
        public virtual int? DesiredAccuracyInMeters
        {
            get
            {
                return (int?)_geolocator.DesiredAccuracyInMeters;
            }
        }

        /// <summary>
        /// Gets the status that indicates the ability of the location service to provide location updates.
        /// </summary>
        /// <value>The status that indicates the ability of the location service to provide location updates.</value>
        public virtual LocationServiceStatus Status
        {
            get
            {
                return _geolocator.LocationStatus.ToLocationServiceStatus();
            }
        }

        /// <summary>
        /// Gets or sets the distance of movement, in meters, relative to the coordinate from the last <see cref="ILocationService.PositionChanged"/> event, that is required for the location service to raise a <see cref="ILocationService.PositionChanged"/> event.
        /// </summary>
        /// <value>The distance of movement, in meters, relative to the coordinate from the last <see cref="ILocationService.PositionChanged"/> event, that is required for the location service to raise a <see cref="ILocationService.PositionChanged"/> event.</value>
        public virtual double MovementThreshold
        {
            get
            {
                return _geolocator.MovementThreshold;
            }
            set
            {
                _geolocator.MovementThreshold = value;
            }
        }

        /// <summary>
        /// Gets or sets the requested minimum time interval between location updates, in milliseconds. If your application requires updates infrequently, set this value so that the location provider can conserve power by calculating location only when needed.
        /// </summary>
        /// <value>The requested minimum time interval between location updates, in milliseconds.</value>
        public virtual int ReportInterval
        {
            get
            {
                return (int)_geolocator.ReportInterval;
            }
            set
            {
                _geolocator.ReportInterval = (uint)value;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationService"/> class.
        /// </summary>
        public LocationService()
        {
            _geolocator = new Geolocator();
        }

        /// <summary>
        /// Starts the acquisition of data from the location service.
        /// </summary>
        public virtual void Start()
        {
            Start(LocationServiceAccuracy.Default);
        }

        /// <summary>
        /// Starts the acquisition of data from the location service.
        /// </summary>
        /// <param name="desiredAccuracy">The desired accuracy.</param>
        public virtual void Start(LocationServiceAccuracy desiredAccuracy)
        {
            _geolocator.DesiredAccuracy = desiredAccuracy.ToPositionAccuracy();
            _geolocator.DesiredAccuracyInMeters = null;

            _geolocator.StatusChanged += GeolocatorStatusChanged;
            _geolocator.PositionChanged += GeolocatorPositionChanged;
        }

        /// <summary>
        /// Starts the acquisition of data from the location service.
        /// </summary>
        /// <param name="desiredAccuracyInMeters">The desired accuracy in meters for data returned from the location service.</param>
        public virtual void Start(int desiredAccuracyInMeters)
        {
            _geolocator.DesiredAccuracyInMeters = (uint)desiredAccuracyInMeters;

            _geolocator.StatusChanged += GeolocatorStatusChanged;
            _geolocator.PositionChanged += GeolocatorPositionChanged;
        }

        /// <summary>
        /// Stops the acquisition of data from the location service.
        /// </summary>
        public virtual void Stop()
        {
            _geolocator.PositionChanged -= GeolocatorPositionChanged;
            _geolocator.StatusChanged -= GeolocatorStatusChanged;
        }

        /// <summary>
        /// Starts an asynchronous operation to retrieve the current location.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task<LocationServicePosition> GetPositionAsync()
        {
            return GetPositionAsync(LocationServiceAccuracy.Default);
        }

        /// <summary>
        /// Starts an asynchronous operation to retrieve the current location.
        /// </summary>
        /// <param name="desiredAccuracy">The desired accuracy.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task<LocationServicePosition> GetPositionAsync(LocationServiceAccuracy desiredAccuracy)
        {
            _geolocator.DesiredAccuracy = desiredAccuracy.ToPositionAccuracy();

            var position = await _geolocator.GetGeopositionAsync();

            return position.Coordinate.ToLocationServicePosition();
        }

        /// <summary>
        /// Starts an asynchronous operation to retrieve the current location.
        /// </summary>
        /// <param name="maximumAge">The maximum acceptable age of cached location data.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual Task<LocationServicePosition> GetPositionAsync(TimeSpan maximumAge, TimeSpan timeout)
        {
            return GetPositionAsync(LocationServiceAccuracy.Default, maximumAge, timeout);
        }

        /// <summary>
        /// Starts an asynchronous operation to retrieve the current location.
        /// </summary>
        /// <param name="desiredAccuracy">The desired accuracy.</param>
        /// <param name="maximumAge">The maximum acceptable age of cached location data.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public virtual async Task<LocationServicePosition> GetPositionAsync(LocationServiceAccuracy desiredAccuracy, TimeSpan maximumAge, TimeSpan timeout)
        {
            _geolocator.DesiredAccuracy = desiredAccuracy.ToPositionAccuracy();

            var getGeopositionAsyncTask = _geolocator.GetGeopositionAsync(maximumAge, timeout).AsTask();

            var completedTask = await Task.WhenAny(getGeopositionAsyncTask, Task.Delay((int)timeout.TotalMilliseconds + 500)).ConfigureAwait(false);

            if (completedTask != getGeopositionAsyncTask)
            {
                throw new TimeoutException();
            }

            var position = await getGeopositionAsyncTask.ConfigureAwait(false);

            return position.Coordinate.ToLocationServicePosition();
        }

        /// <summary>
        /// Requests the access asynchronous.
        /// </summary>
        /// <returns>
        /// Geolocation Access Status
        /// </returns>
        public virtual async Task<GeolocationAccessStatus> RequestAccessAsync()
        {
#if WINDOWS_UWP
            var status = await Geolocator.RequestAccessAsync();
            return status.ToGeolocationAccessStatus();
#else
            return GeolocationAccessStatus.Allowed;
#endif
        }

        private void GeolocatorPositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            RaisePositionChanged(args.ToLocationServicePositionChangedEventArgs());
        }

        private void GeolocatorStatusChanged(Geolocator sender, StatusChangedEventArgs args)
        {
            RaiseStatusChanged(args.ToLocationServiceStatusChangedEventArgs());
        }

        /// <summary>
        /// Raises the <see cref="PositionChanged"/> event with the provided event data.
        /// </summary>
        /// <param name="eventArgs">The event data.</param>
        protected virtual void RaisePositionChanged(LocationServicePositionChangedEventArgs eventArgs)
        {
            var eventHandler = PositionChanged;

            if (eventHandler != null)
            {
                eventHandler(this, eventArgs);
            }
        }

        /// <summary>
        /// Raises the <see cref="StatusChanged"/> event with the provided event data.
        /// </summary>
        /// <param name="eventArgs">The event data.</param>
        protected virtual void RaiseStatusChanged(LocationServiceStatusChangedEventArgs eventArgs)
        {
            var eventHandler = StatusChanged;

            if (eventHandler != null)
            {
                eventHandler(this, eventArgs);
            }
        }
    }
}