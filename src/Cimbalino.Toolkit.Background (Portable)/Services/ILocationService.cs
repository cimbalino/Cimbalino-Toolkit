// ****************************************************************************
// <copyright file="ILocationService.cs" company="Pedro Lamas">
// Copyright © Pedro Lamas 2014
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <project>Cimbalino.Toolkit.Background</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using System;
using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents a service capable of handling the device location capabilities.
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// Occurs when the location service detects a change in position.
        /// </summary>
        event EventHandler<LocationServicePositionChangedEventArgs> PositionChanged;

        /// <summary>
        /// Occurs when the status of the location service changes.
        /// </summary>
        event EventHandler<LocationServiceStatusChangedEventArgs> StatusChanged;

        /// <summary>
        /// Gets the accuracy level at which the location service provides location updates.
        /// </summary>
        /// <value>The accuracy level at which the location service provides location updates.</value>
        LocationServiceAccuracy DesiredAccuracy { get; }

        /// <summary>
        /// Gets the desired accuracy in meters for data returned from the location service.
        /// </summary>
        /// <value>The desired accuracy in meters for data returned from the location service.</value>
        int? DesiredAccuracyInMeters { get; }

        /// <summary>
        /// Gets the status that indicates the ability of the location service to provide location updates.
        /// </summary>
        /// <value>The status that indicates the ability of the location service to provide location updates.</value>
        LocationServiceStatus Status { get; }

        /// <summary>
        /// Gets or sets the distance of movement, in meters, relative to the coordinate from the last <see cref="PositionChanged"/> event, that is required for the location service to raise a <see cref="PositionChanged"/> event.
        /// </summary>
        /// <value>The distance of movement, in meters, relative to the coordinate from the last <see cref="PositionChanged"/> event, that is required for the location service to raise a <see cref="PositionChanged"/> event.</value>
        double MovementThreshold { get; set; }

        /// <summary>
        /// Gets or sets the requested minimum time interval between location updates, in milliseconds. If your application requires updates infrequently, set this value so that the location provider can conserve power by calculating location only when needed.
        /// </summary>
        /// <value>The requested minimum time interval between location updates, in milliseconds.</value>
        int ReportInterval { get; set; }

        /// <summary>
        /// Starts the acquisition of data from the location service.
        /// </summary>
        void Start();

        /// <summary>
        /// Starts the acquisition of data from the location service.
        /// </summary>
        /// <param name="desiredAccuracy">The desired accuracy.</param>
        void Start(LocationServiceAccuracy desiredAccuracy);

        /// <summary>
        /// Starts the acquisition of data from the location service.
        /// </summary>
        /// <param name="desiredAccuracyInMeters">The desired accuracy in meters for data returned from the location service.</param>
        void Start(int desiredAccuracyInMeters);

        /// <summary>
        /// Stops the acquisition of data from the location service.
        /// </summary>
        void Stop();

        /// <summary>
        /// Retrieves the current location.
        /// </summary>
        /// <param name="locationResult">The current location.</param>
        void GetPosition(Action<LocationServicePosition, Exception> locationResult);

        /// <summary>
        /// Retrieves the current location.
        /// </summary>
        /// <param name="desiredAccuracy">The desired accuracy.</param>
        /// <param name="locationResult">The current location.</param>
        void GetPosition(LocationServiceAccuracy desiredAccuracy, Action<LocationServicePosition, Exception> locationResult);

        /// <summary>
        /// Retrieves the current location.
        /// </summary>
        /// <param name="maximumAge">The maximum acceptable age of cached location data.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="locationResult">The current location.</param>
        void GetPosition(TimeSpan maximumAge, TimeSpan timeout, Action<LocationServicePosition, Exception> locationResult);

        /// <summary>
        /// Retrieves the current location.
        /// </summary>
        /// <param name="desiredAccuracy">The desired accuracy.</param>
        /// <param name="maximumAge">The maximum acceptable age of cached location data.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="locationResult">The current location.</param>
        void GetPosition(LocationServiceAccuracy desiredAccuracy, TimeSpan maximumAge, TimeSpan timeout, Action<LocationServicePosition, Exception> locationResult);

        /// <summary>
        /// Starts an asynchronous operation to retrieve the current location.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<LocationServicePosition> GetPositionAsync();

        /// <summary>
        /// Starts an asynchronous operation to retrieve the current location.
        /// </summary>
        /// <param name="desiredAccuracy">The desired accuracy.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<LocationServicePosition> GetPositionAsync(LocationServiceAccuracy desiredAccuracy);

        /// <summary>
        /// Starts an asynchronous operation to retrieve the current location.
        /// </summary>
        /// <param name="maximumAge">The maximum acceptable age of cached location data.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<LocationServicePosition> GetPositionAsync(TimeSpan maximumAge, TimeSpan timeout);

        /// <summary>
        /// Starts an asynchronous operation to retrieve the current location.
        /// </summary>
        /// <param name="desiredAccuracy">The desired accuracy.</param>
        /// <param name="maximumAge">The maximum acceptable age of cached location data.</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        Task<LocationServicePosition> GetPositionAsync(LocationServiceAccuracy desiredAccuracy, TimeSpan maximumAge, TimeSpan timeout);
    }
}