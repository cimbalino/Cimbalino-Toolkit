// ****************************************************************************
// <copyright file="WindowsPhoneStoreService.cs" company="Pedro Lamas">
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
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using Cimbalino.Toolkit.Extensions;
using Cimbalino.Toolkit.Helpers;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IWindowsPhoneStoreService"/>.
    /// </summary>
    public class WindowsPhoneStoreService : IWindowsPhoneStoreService
    {
        /// <summary>
        /// Retrieves store information about the running application.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<WindowsPhoneStoreServiceAppNode> GetAppInformationAsync()
        {
            return GetAppInformationAsync(ApplicationManifest.Current.App.ProductId);
        }

        /// <summary>
        /// Retrieves store information about the running application.
        /// </summary>
        /// <param name="productId">The application Product ID.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<WindowsPhoneStoreServiceAppNode> GetAppInformationAsync(string productId)
        {
            var request = CreateWebRequest(productId);

            return Task.Factory.FromAsync<WindowsPhoneStoreServiceAppNode>(request.BeginGetResponse, WebRequestEndGetResponse, request);
        }

        private WebRequest CreateWebRequest(string productId)
        {
            var url = string.Format("http://marketplaceedgeservice.windowsphone.com/v9/catalog/apps/{0}?os=8.1.0.0&cc={1}&oc=&lang={2}​",
                productId.TrimStart('{').TrimEnd('}'),
                RegionInfo.CurrentRegion.TwoLetterISORegionName,
                CultureInfo.CurrentUICulture.Name);

            var request = WebRequest.Create(url);

            request.SetNoCacheHeaders();

            return request;
        }

        private WindowsPhoneStoreServiceAppNode WebRequestEndGetResponse(IAsyncResult asyncResult)
        {
            var request = (WebRequest)asyncResult.AsyncState;

            using (var response = (HttpWebResponse)request.EndGetResponse(asyncResult))
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new WebException("Http Error: " + response.StatusCode);
                }

                using (var outputStream = response.GetResponseStream())
                {
                    using (var reader = XmlReader.Create(outputStream, new XmlReaderSettings { IgnoreWhitespace = true, IgnoreComments = true }))
                    {
                        return WindowsPhoneStoreServiceAppNode.ParseXml(reader);
                    }
                }
            }
        }
    }
}