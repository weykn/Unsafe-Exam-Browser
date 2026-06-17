/*
 * Copyright (c) 2026 ETH Zürich, IT Services
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System.Windows.Forms;
using CefSharp;
using SafeExamBrowser.UserInterface.Contracts;

namespace SafeExamBrowser.Browser.Handlers
{
	internal class KeyboardHandler : IKeyboardHandler
	{
		internal event ActionRequestedEventHandler NewTabRequested;
		internal event ActionRequestedEventHandler HideTabsRequested;
		internal event ActionRequestedEventHandler ShowTabsRequested;

		public bool OnKeyEvent(IWebBrowser browserControl, IBrowser browser, KeyType type, int keyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey)
		{
			var ctrl = modifiers.HasFlag(CefEventFlags.ControlDown);

			if (type == KeyType.KeyUp && ctrl)
			{
				if (keyCode == (int) Keys.T)
				{
					NewTabRequested?.Invoke();
				}

				if (keyCode == (int) Keys.H)
				{
					HideTabsRequested?.Invoke();
				}

				if (keyCode == (int) Keys.J)
				{
					ShowTabsRequested?.Invoke();
				}
			}

			return false;
		}

		public bool OnPreKeyEvent(IWebBrowser browserControl, IBrowser browser, KeyType type, int keyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
		{
			return false;
		}
	}
}
