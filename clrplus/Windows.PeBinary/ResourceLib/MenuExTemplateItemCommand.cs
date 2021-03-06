﻿//-----------------------------------------------------------------------
// <copyright company="CoApp Project">
//     ResourceLib Original Code from http://resourcelib.codeplex.com
//     Original Copyright (c) 2008-2009 Vestris Inc.
//     Changes Copyright (c) 2011 Garrett Serack . All rights reserved.
// </copyright>
// <license>
// MIT License
// You may freely use and distribute this software under the terms of the following license agreement.
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated 
// documentation files (the "Software"), to deal in the Software without restriction, including without limitation 
// the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and 
// to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of 
// the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO 
// THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, 
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE
// </license>
//-----------------------------------------------------------------------

namespace ClrPlus.Windows.PeBinary.ResourceLib {
    using System;
    using System.Text;
    using Api.Enumerations;

    /// <summary>
    ///     A command menu item.
    /// </summary>
    public class MenuExTemplateItemCommand : MenuExTemplateItem {
        /// <summary>
        ///     Returns true if the item is a separator.
        /// </summary>
        public bool IsSeparator {
            get {
                return _header.dwType == (uint)MenuFlags.MFT_SEPARATOR ||
                    ((_header.bResInfo == 0xFFFF || _header.bResInfo == 0) && _header.dwMenuId == 0 && _menuString == null);
            }
        }

        /// <summary>
        ///     String representation in the MENU format.
        /// </summary>
        /// <param name="indent">Indent.</param>
        /// <returns>String representation.</returns>
        public override string ToString(int indent) {
            var sb = new StringBuilder();
            if (IsSeparator) {
                sb.AppendLine(string.Format("{0}MENUITEM SEPARATOR", new String(' ', indent)));
            } else {
                sb.AppendLine(string.Format("{0}MENUITEM \"{1}\", {2}", new String(' ', indent),
                    _menuString == null ? string.Empty : _menuString.Replace("\t", @"\t"), _header.dwMenuId));
            }
            return sb.ToString();
        }
    }
}