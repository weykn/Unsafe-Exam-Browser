/*
 * Copyright (c) 2026 ETH Zürich, IT Services
 * 
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at http://mozilla.org/MPL/2.0/.
 */

using SafeExamBrowser.Browser.Handlers;
using SafeExamBrowser.UserInterface.Contracts;

namespace SafeExamBrowser.Browser.Responsibilities.Window
{
	internal class KeyboardResponsibility : WindowResponsibility
	{
		private readonly KeyboardHandler keyboardHandler;

		internal event ActionRequestedEventHandler NewTabRequested;
		internal event ActionRequestedEventHandler HideTabsRequested;
		internal event ActionRequestedEventHandler ShowTabsRequested;

		public KeyboardResponsibility(BrowserWindowContext context, KeyboardHandler keyboardHandler) : base(context)
		{
			this.keyboardHandler = keyboardHandler;
		}

		public override void Assume(WindowTask task)
		{
			if (task == WindowTask.RegisterEvents)
			{
				RegisterEvents();
			}
		}

		private void RegisterEvents()
		{
			keyboardHandler.NewTabRequested += () => NewTabRequested?.Invoke();
			keyboardHandler.HideTabsRequested += () => HideTabsRequested?.Invoke();
			keyboardHandler.ShowTabsRequested += () => ShowTabsRequested?.Invoke();
		}
	}
}
