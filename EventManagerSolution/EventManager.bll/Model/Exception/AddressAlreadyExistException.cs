namespace EventManager.bll.Model.Exception;
using System;

public class AddressAlreadyExistException : Exception
{
    public AddressAlreadyExistException() : base("This address is already used"){}
}