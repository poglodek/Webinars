﻿namespace Webinars.Common
{
    public enum OperationStatusCode
    {
        OK = 200,
        CREATED = 201,
        ACCEPTED = 202,
        NO_CONTENT = 204,
        BAD_REQUEST = 400,
        UNAUTHORIZED = 401,
        FORBIDDEN = 403,
        NOT_FOUND = 404,
        METHOD_NOT_ALLOWED = 405,
        NOT_ACCEPTABLE = 406,
        CONFLICT = 409,
        INTERNAL_SERVER_ERROR = 500,
        
    }
}