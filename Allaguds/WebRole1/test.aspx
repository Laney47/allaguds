<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WebRole1.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="google-signin-scope" content="profile email">
    <meta name="google-signin-client_id" content="232858626298-g9i4egtmrmodtlhikuhl8ffsc31b0uh9.apps.googleusercontent.com">
    <script src="https://apis.google.com/js/platform.js" async defer></script>
</head>
<body>

    <div class="g-signin2" data-onsuccess="onSignIn" data-theme="dark"></div>
    <script>
        function onSignIn(googleUser) {
            // Useful data for your client-side scripts:
            var profile = googleUser.getBasicProfile();
            console.log("ID: " + profile.getId()); // Don't send this directly to your server!
            console.log('Full Name: ' + profile.getName());
            console.log('Given Name: ' + profile.getGivenName());
            console.log('Family Name: ' + profile.getFamilyName());
            console.log("Image URL: " + profile.getImageUrl());
            console.log("Email: " + profile.getEmail());

            // The ID token you need to pass to your backend:
            var id_token = googleUser.getAuthResponse().id_token;
            console.log("ID Token: " + id_token);

            $.ajax({
                type: "POST",
                url: "test.aspx/MyMethod",
                data: JSON.stringify(profile.getEmail),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert(data.d);
                },
                error: function (result) {
                    console.warn(result.statusText);
                }
            });
        };

        function signOut() {
            var auth2 = gapi.auth2.getAuthInstance();
            auth2.signOut().then(function () {
                console.log('User signed out.');
            });
        }
    </script>
    <a href="#" onclick="signOut();">Sign out</a>
    <form id="form1" runat="server">
        <div>
            username:
        <asp:TextBox ID="userBox" runat="server" OnTextChanged="TextBox1_TextChanged" Style="height: 22px"></asp:TextBox>
            <br />
            password:
            <asp:TextBox ID="passBox" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Sign in" />
            <br />
            <br />
            <asp:Label ID="textLabel" runat="server" Text="Label"></asp:Label>
            <br />
            <!--<div class="fb-login-button" data-max-rows="1" data-size="medium" data-button-type="login_with" data-show-faces="false" data-auto-logout-link="true" data-use-continue-as="false"></div>
            <div class="g-signin2" data-onsuccess="onSignIn" data-theme="dark"></div>
                -->
            <br />
            <br />

            
        </div>
    </form>

</body>
</html>
