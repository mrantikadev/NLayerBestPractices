﻿using System.Net;
using System.Text.Json.Serialization;

namespace App.Services
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }
        public List<string>? ErrorMessage { get; set; }
        [JsonIgnore] public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;
        [JsonIgnore] public bool IsFailure => !IsSuccess;
        [JsonIgnore] public HttpStatusCode Status { get; set; }
        [JsonIgnore] public string? UrlAsCreated { get; set; }

        // Static Factory Methods
        public static ServiceResult<T> Success(T data, HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult<T>
            {
                Data = data,
                Status = status
            };
        }

        public static ServiceResult<T> SuccessAsCreated(T data, string urlAsCreated)
        {
            return new ServiceResult<T>
            {
                Data = data,
                Status = HttpStatusCode.Created,
                UrlAsCreated = urlAsCreated
            };
        }

        public static ServiceResult<T> Failure(List<string> errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>
            {
                ErrorMessage = errorMessage,
                Status = status
            };
        }

        public static ServiceResult<T> Failure(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>
            {
                ErrorMessage = new List<string> { errorMessage },
                Status = status
            };
        }
    }

    public class ServiceResult
    {
        public List<string>? ErrorMessage { get; set; }
        [JsonIgnore] public bool IsSuccess => ErrorMessage == null || ErrorMessage.Count == 0;
        [JsonIgnore] public bool IsFailure => !IsSuccess;
        [JsonIgnore] public HttpStatusCode Status { get; set; }

        // Static Factory Methods
        public static ServiceResult Success(HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult
            {
                Status = status
            };
        }

        public static ServiceResult Failure(List<string> errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult
            {
                ErrorMessage = errorMessage,
                Status = status
            };
        }

        public static ServiceResult Failure(string errorMessage, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult
            {
                ErrorMessage = new List<string> { errorMessage },
                Status = status
            };
        }
    }
}
