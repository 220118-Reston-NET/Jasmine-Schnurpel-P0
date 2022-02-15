using Xunit;
using Models;

namespace Test;
public class CustomerModelTest
{
    [Fact]
    public void CustomerShouldSetValidData()
    {
        CustomerModel _user = new CustomerModel();
        string _userID = "0";
        string _userName = "Jasmine";
        int _userLevel = 101;
        string _userAddress = "713 Mulberry Ln";
        string _userEmail = "jasmine.schnurpel@revature.net";

        _user.UserID = _userID;
        _user.UserName = _userName;
        _user.UserLevel = _userLevel;
        _user.UserAddress = _userAddress;
        _user.UserEmail = _userEmail;

        Assert.NotNull(_userID);
        Assert.NotNull(_userName);
        Assert.NotNull(_userLevel);
        Assert.NotNull(_userAddress);
        Assert.NotNull(_userEmail);
    }
}