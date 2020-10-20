﻿using Dynamo.Configuration;
using Dynamo.Controls;
using Dynamo.Models;
using Dynamo.Scheduler;
using Dynamo.ViewModels;
using Dynamo.Wpf;
using Speckle.ConnectorDynamo.UI;
using System.Windows;
using System.Windows.Threading;

namespace Speckle.ConnectorDynamo.SendNode
{
  public class SendViewCustomization : INodeViewCustomization<Send>
  {

    private DynamoViewModel dynamoViewModel;
    private DispatcherSynchronizationContext syncContext;
    private Send sendNode;
    private DynamoModel dynamoModel;

    public void CustomizeView(Send model, NodeView nodeView)
    {
      dynamoModel = nodeView.ViewModel.DynamoViewModel.Model;
      dynamoViewModel = nodeView.ViewModel.DynamoViewModel;
      syncContext = new DispatcherSynchronizationContext(nodeView.Dispatcher);
      sendNode = model;

      var ui = new SendUi();
      nodeView.inputGrid.Children.Add(ui);

      //bindings
      ui.DataContext = model;
      //ui.Loaded += model.AddedToDocument;
      ui.SendStreamButton.Click += SendStreamButtonClick;

    }

    private void SendStreamButtonClick(object sender, RoutedEventArgs e)
    {
      var s = dynamoViewModel.Model.Scheduler;

      // prevent data race by running on scheduler
      var t = new DelegateBasedAsyncTask(s, () =>
      {
        sendNode.DoSend(dynamoModel.EngineController);
      });

      // then update on the ui thread
      //t.ThenSend((_) =>
      //{
      //  var bmp = CreateColorRangeBitmap(colorRange);
      //  gradientImage.Source = bmp;
      //}, syncContext);

      s.ScheduleForExecution(t);
    }




    public void Dispose() { }

  }
}
