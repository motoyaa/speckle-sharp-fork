﻿using Speckle.Core.Api;
using Speckle.Core.Credentials;
using System.Collections.Generic;

namespace DesktopUI2.ViewModels.DesignViewModels
{
  public class DesignAllStreamsViewModel
  {
    public bool InProgress { get; set; } = false;

    public Account SelectedAccount { get; set; } = null;

    public List<Account> Accounts { get; set; } = new List<Account>();

    public string SearchQuery { get; set; }

    public List<Stream> Streams { get; set; } = new List<Stream>();

    public DesignAllStreamsViewModel()
    {
      var acc = AccountManager.GetDefaultAccount();
      var client = new Client(acc);
      Streams = client.StreamsGet().Result;
    }

    public void NewStreamCommand()
    {

    }

    public void AddFromUrlCommand()
    {
    }
  }
}
