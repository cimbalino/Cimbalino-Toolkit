// ****************************************************************************
// <copyright file="AssemblyInfo.cs" company="Pedro Lamas">
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

#if NETFX_CORE
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#else
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
#endif

[assembly: ComVisible(false)]
#if !NETFX_CORE
[assembly: CLSCompliant(true)]
#endif
[assembly: InternalsVisibleTo("Cimbalino.Toolkit")]
[assembly: InternalsVisibleTo("Cimbalino.Toolkit.Controls")]
