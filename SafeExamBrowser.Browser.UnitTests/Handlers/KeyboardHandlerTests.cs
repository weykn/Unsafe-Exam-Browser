/*
 * Copyright (c) 2026 ETH Zürich, IT Services
 *
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using System.Windows.Forms;
using CefSharp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SafeExamBrowser.Browser.Handlers;

namespace SafeExamBrowser.Browser.UnitTests.Handlers
{
	[TestClass]
	public class KeyboardHandlerTests
	{
		private KeyboardHandler sut;

		[TestInitialize]
		public void Initialize()
		{
			sut = new KeyboardHandler();
		}

		[TestMethod]
		public void MustDetectNewTabCommand()
		{
			var newTabRequested = false;

			sut.NewTabRequested += () => newTabRequested = true;

			var handled = sut.OnKeyEvent(default(IWebBrowser), default(IBrowser), KeyType.KeyUp, (int) Keys.T, default(int), CefEventFlags.ControlDown, default(bool));

			Assert.IsTrue(newTabRequested);
			Assert.IsFalse(handled);

			newTabRequested = false;
			handled = sut.OnKeyEvent(default(IWebBrowser), default(IBrowser), default(KeyType), default(int), default(int), CefEventFlags.ControlDown, default(bool));

			Assert.IsFalse(newTabRequested);
			Assert.IsFalse(handled);
		}

		[TestMethod]
		public void MustDetectHideTabsCommand()
		{
			var hideTabsRequested = false;

			sut.HideTabsRequested += () => hideTabsRequested = true;

			var handled = sut.OnKeyEvent(default(IWebBrowser), default(IBrowser), KeyType.KeyUp, (int) Keys.H, default(int), CefEventFlags.ControlDown, default(bool));

			Assert.IsTrue(hideTabsRequested);
			Assert.IsFalse(handled);

			hideTabsRequested = false;
			handled = sut.OnKeyEvent(default(IWebBrowser), default(IBrowser), KeyType.KeyUp, (int) Keys.H, default(int), default(CefEventFlags), default(bool));

			Assert.IsFalse(hideTabsRequested);
			Assert.IsFalse(handled);
		}

		[TestMethod]
		public void MustDetectShowTabsCommand()
		{
			var showTabsRequested = false;

			sut.ShowTabsRequested += () => showTabsRequested = true;

			var handled = sut.OnKeyEvent(default(IWebBrowser), default(IBrowser), KeyType.KeyUp, (int) Keys.J, default(int), CefEventFlags.ControlDown, default(bool));

			Assert.IsTrue(showTabsRequested);
			Assert.IsFalse(handled);

			showTabsRequested = false;
			handled = sut.OnKeyEvent(default(IWebBrowser), default(IBrowser), KeyType.KeyUp, (int) Keys.J, default(int), default(CefEventFlags), default(bool));

			Assert.IsFalse(showTabsRequested);
			Assert.IsFalse(handled);
		}

		[TestMethod]
		public void MustNotHandleAnyKeyInPreKeyEvent()
		{
			var isShortcut = default(bool);

			var handled = sut.OnPreKeyEvent(default(IWebBrowser), default(IBrowser), KeyType.KeyUp, (int) Keys.F5, default(int), default(CefEventFlags), default(bool), ref isShortcut);

			Assert.IsFalse(handled);
		}
	}
}
