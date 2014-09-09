// ****************************************************************************
// <copyright file="ObservableTask.cs" company="Pedro Lamas">
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

using System.Threading.Tasks;

namespace Cimbalino.Toolkit.Helpers
{
    /// <summary>
    /// Helper class that will notify any listener for task completion.
    /// </summary>
    public class ObservableTask : ObservableTaskBase<Task>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObservableTask"/> class.
        /// </summary>
        /// <param name="task">The associated task instance.</param>
        public ObservableTask(Task task)
            : base(task)
        {
        }
    }
}