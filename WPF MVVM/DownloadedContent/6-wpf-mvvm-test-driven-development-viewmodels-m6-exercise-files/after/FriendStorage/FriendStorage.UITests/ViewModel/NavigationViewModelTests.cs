﻿using FriendStorage.UI.DataProvider;
using FriendStorage.UI.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FriendStorage.Model;
using Moq;
using Prism.Events;
using FriendStorage.UI.Events;

namespace FriendStorage.UITests.ViewModel
{
  public class NavigationViewModelTests
  {
    private NavigationViewModel _viewModel;
    private FriendSavedEvent _friendSavedEvent;

    public NavigationViewModelTests()
    {
      _friendSavedEvent = new FriendSavedEvent();
      
      var eventAggregatorMock = new Mock<IEventAggregator>();
      eventAggregatorMock.Setup(ea => ea.GetEvent<FriendSavedEvent>())
        .Returns(_friendSavedEvent);

      var navigationDataProviderMock = new Mock<INavigationDataProvider>();
      navigationDataProviderMock.Setup(dp => dp.GetAllFriends())
        .Returns(new List<LookupItem>
        {
          new LookupItem { Id = 1, DisplayMember = "Julia" },
          new LookupItem { Id = 2, DisplayMember = "Thomas" }
       });
      _viewModel = new NavigationViewModel(
        navigationDataProviderMock.Object,
        eventAggregatorMock.Object);
    }

    [Fact]
    public void ShouldLoadFriends()
    {
      _viewModel.Load();

      Assert.Equal(2, _viewModel.Friends.Count);

      var friend = _viewModel.Friends.SingleOrDefault(f => f.Id == 1);
      Assert.NotNull(friend);
      Assert.Equal("Julia", friend.DisplayMember);

      friend = _viewModel.Friends.SingleOrDefault(f => f.Id == 2);
      Assert.NotNull(friend);
      Assert.Equal("Thomas", friend.DisplayMember);
    }

    [Fact]
    public void ShouldLoadFriendsOnlyOnce()
    {
      _viewModel.Load();
      _viewModel.Load();

      Assert.Equal(2, _viewModel.Friends.Count);
    }

    [Fact]
    public void ShouldUpdateNavigationItemWhenFriendIsSaved()
    {
      _viewModel.Load();
      var navigationItem = _viewModel.Friends.First();

      var friendId = navigationItem.Id;

      _friendSavedEvent.Publish(
        new Friend
        {
          Id = friendId,
          FirstName = "Anna",
          LastName = "Huber"
        });

      Assert.Equal("Anna Huber", navigationItem.DisplayMember);
    }
  }
}
