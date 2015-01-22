// ****************************************************************************
// <copyright file="WindowsStoreService.cs" company="Pedro Lamas">
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
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml;
using Cimbalino.Toolkit.Extensions;
using Windows.ApplicationModel;
using Windows.Globalization;

namespace Cimbalino.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IWindowsStoreService"/>.
    /// </summary>
    public class WindowsStoreService : IWindowsStoreService
    {
        /// <summary>
        /// Retrieves store information about the running application.
        /// </summary>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<WindowsStoreServiceAppNode> GetAppInformationAsync()
        {
            return GetAppInformationAsync(Package.Current.Id.Name);
        }

        /// <summary>
        /// Retrieves store information about the running application.
        /// </summary>
        /// <param name="productId">The application Product ID.</param>
        /// <returns>The <see cref="Task"/> object representing the asynchronous operation.</returns>
        public Task<WindowsStoreServiceAppNode> GetAppInformationAsync(string productId)
        {
            var request = CreateWebRequest(productId);

            return Task.Factory.FromAsync<WindowsStoreServiceAppNode>(request.BeginGetResponse, WebRequestEndGetResponse, request);
        }

        private WebRequest CreateWebRequest(string productId)
        {
            var country = new GeographicRegion().CodeTwoLetter;
            var languages = string.Join(string.Empty, ApplicationLanguages.Languages.Select((x, i) =>
            {
                if (i == 1)
                {
                    return "_" + x;
                }
                if (i > 1)
                {
                    return "." + x;
                }

                return x;
            }));

            ////https://next-services.apps.microsoft.com/browse/{osVersion}.{osBuild}-{appModel}/{clientVersion}/{chromeLocale}_{localeList}/c/{country}/cp/{channelPartner}/Apps/{appId}

            var url = string.Format("https://next-services.apps.microsoft.com/browse/6.3.9600-0/776/{2}/c/{1}/cp/0/Apps/{0}",
                productId.TrimStart('{').TrimEnd('}'),
                country,
                languages);

            var request = WebRequest.Create(url);

            request.SetNoCacheHeaders();

            return request;
        }

        private WindowsStoreServiceAppNode WebRequestEndGetResponse(IAsyncResult asyncResult)
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
                        return WindowsStoreServiceAppNode.ParseXml(reader);
                    }
                }
            }
        }
    }
}