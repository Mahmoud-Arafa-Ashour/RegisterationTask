﻿namespace RegisterationTask.Dto
{
    public record AuthResponse(string Id,string Email ,string FirstName , string LastName , string Token , int ExpireIn);
}
