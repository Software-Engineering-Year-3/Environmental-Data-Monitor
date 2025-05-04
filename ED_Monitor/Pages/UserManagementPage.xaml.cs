using ED_Monitor.Data;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace ED_Monitor.Pages
{
    public partial class UserManagementPage : ContentPage
    {
        // Backing collection for the UI
        public ObservableCollection<MockUser> Users { get; set; } = new();

        // Possible roles to choose from
        public List<string> RoleOptions { get; } = new() { "Scientist", "Manager", "Admin" };

        public UserManagementPage()
        {
            InitializeComponent();
            BindingContext = this;
            LoadUsers(); // grab existing users at startup
        }

        // Populate the ObservableCollection from our store
        private void LoadUsers()
        {
            Users.Clear();
            foreach (var user in MockUserStore.Users.Values)
                Users.Add(user);
        }

        // Fired when the Delete button is tapped
        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.BindingContext is MockUser user)
            {
                // confirm before removing
                bool ok = await DisplayAlert(
                    "Confirm Delete",
                    $"Remove user {user.Name} ({user.Email})?",
                    "Yes", "Cancel");
                if (!ok) 
                    return;

                // remove from store and update UI
                MockUserStore.Users.Remove(user.Email);
                MockUserStore.SaveUsers();
                Users.Remove(user);
            }
        }

        // Fired when the user picks a new role
        private async void OnRoleChanged(object sender, EventArgs e)
        {
            if (sender is Picker picker && picker.BindingContext is MockUser user)
            {
                // ask before committing role change
                bool ok = await DisplayAlert(
                    "Confirm Role Change",
                    $"Change {user.Name}'s role to {picker.SelectedItem}?",
                    "Yes", "Cancel");
                if (!ok)
                {
                    // back out if they cancel
                    picker.SelectedItem = user.Role;
                    return;
                }

                // apply the change
                string newRole = picker.SelectedItem?.ToString() ?? user.Role;
                user.Role = newRole;
                MockUserStore.Users[user.Email] = user;
                MockUserStore.SaveUsers();
            }
        }
    }
}
