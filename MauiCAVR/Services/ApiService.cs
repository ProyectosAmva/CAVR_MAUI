﻿using MauiCAVR.Models;
using System.Net.Http.Headers;
using System.Text;

namespace MauiCAVR.Services;

public class ApiService
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public async Task<Response> CheckConnection()
    {
        NetworkAccess accessType = Connectivity.Current.NetworkAccess;
        try
        {
            if (accessType != NetworkAccess.Internet)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = AppResource.ConnectionError,
                };
            }
            return new Response
            {
                IsSuccess = true,
                Message = "Ok",
            };
        }
        catch (Exception exp)
        {
            return new Response
            {
                IsSuccess = false,
                Message = exp.Message,
            };
        }
    }

    public async Task<Response> ChangePassword(
        string urlBase,
        string servicePrefix,
        string controller,
        string tokenType,
        string accessToken, ChangePasswordRequest changePasswordRequest)
    {
        try
        {
            var request = JsonConvert.SerializeObject(changePasswordRequest);
            var content = new StringContent(request, Encoding.UTF8, "application/json");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
            client.BaseAddress = new Uri(urlBase);
            var url = string.Format("{0}{1}", servicePrefix, controller);
            var response = await client.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                return new Response
                {
                    IsSuccess = false,
                };
            }

            return new Response
            {
                IsSuccess = true,
            };
        }
        catch (Exception ex)
        {
            return new Response
            {
                IsSuccess = false,
                Message = ex.Message,
            };
        }
    }


    public async Task<TokenResponse> GetToken(
        string urlBase,
        string username,
        string password)
    {
        try
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(urlBase);
            var response = await client.PostAsync("Token",
                new StringContent(string.Format(
                "grant_type=password&username={0}&password={1}",
                username, password),
                Encoding.UTF8, "application/x-www-form-urlencoded"));
            var resultJSON = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TokenResponse>(
                resultJSON);
            return result!;
        }
        catch (Exception exp)
        {
            return null!;
        }
    }

    public async Task<Response> Get<T>(
        string urlBase,
        string servicePrefix,
        string controller,
        string tokenType,
        string accessToken,
        int id)
    {
        try
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(tokenType, accessToken);
            client.BaseAddress = new Uri(urlBase);
            var url = string.Format(
                "{0}{1}/{2}",
                servicePrefix,
                controller,
                id);
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = response.StatusCode.ToString(),
                };
            }

            var result = await response.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<T>(result);
            return new Response
            {
                IsSuccess = true,
                Message = "Ok",
                Result = model!,
            };
        }
        catch (Exception ex)
        {
            return new Response
            {
                IsSuccess = false,
                Message = ex.Message,
            };
        }
    }

    public async Task<Response> GetList<T>(
        string urlBase,
        string servicePrefix,
        string controller)
    {
        try
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(urlBase);
            var url = string.Format("{0}{1}", servicePrefix, controller);
            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = result,
                };
            }

            var list = JsonConvert.DeserializeObject<List<T>>(result);
            return new Response
            {
                IsSuccess = true,
                Message = "Ok",
                Result = list!,
            };
        }
        catch (Exception ex)
        {
            return new Response
            {
                IsSuccess = false,
                Message = ex.Message,
            };
        }
    }

    public async Task<Response> GetList<T>(
        string urlBase,
        string servicePrefix,
        string controller,
        string tokenType,
        string accessToken)
    {
        try
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(tokenType, accessToken);
            client.BaseAddress = new Uri(urlBase);
            var url = string.Format("{0}{1}", servicePrefix, controller);
            var response = await client.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = result,
                };
            }

            var list = JsonConvert.DeserializeObject<List<T>>(result);
            return new Response
            {
                IsSuccess = true,
                Message = "Ok",
                Result = list!,
            };
        }
        catch (Exception ex)
        {
            return new Response
            {
                IsSuccess = false,
                Message = ex.Message,
            };
        }
    }

    public async Task<Response> GetList<T>(
        string urlBase,
        string servicePrefix,
        string controller,
        string tokenType,
        string accessToken,
        int id)
    {
        try
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(tokenType, accessToken);
            client.BaseAddress = new Uri(urlBase);
            var url = string.Format(
                "{0}{1}/{2}",
                servicePrefix,
                controller,
                id);
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = response.StatusCode.ToString(),
                };
            }

            var result = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject<List<T>>(result);
            return new Response
            {
                IsSuccess = true,
                Message = "Ok",
                Result = list!,
            };
        }
        catch (Exception ex)
        {
            return new Response
            {
                IsSuccess = false,
                Message = ex.Message,
            };
        }
    }

    public async Task<Response> Post<T>(
        string urlBase,
        string servicePrefix,
        string controller,
        string tokenType,
        string accessToken,
        T model)
    {
        try
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(
                request, Encoding.UTF8,
                "application/json");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(tokenType, accessToken);
            client.BaseAddress = new Uri(urlBase);
            var url = string.Format("{0}{1}", servicePrefix, controller);
            var response = await client.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<Response>(result);
                error!.IsSuccess = false;
                return error;
            }

            var newRecord = JsonConvert.DeserializeObject<RtaTransaccion>(result);

            return new Response
            {
                IsSuccess = true,
                Message = "Record added OK",
                Result = newRecord!,
            };
        }
        catch (Exception ex)
        {
            return new Response
            {
                IsSuccess = false,
                Message = ex.Message,
            };
        }
    }

    public async Task<Response> Post<T>(
        string urlBase,
        string servicePrefix,
        string controller,
        T model)
    {
        try
        {

            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(
                request,
                Encoding.UTF8,
                "application/json");
            var client = new HttpClient();
            client.BaseAddress = new Uri(urlBase);
            var url = string.Format("{0}{1}", servicePrefix, controller);
            var response = await client.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = response.StatusCode.ToString(),
                };
            }

            var result = await response.Content.ReadAsStringAsync();
            var newRecord = JsonConvert.DeserializeObject<T>(result);

            return new Response
            {
                IsSuccess = true,
                Message = "Record added OK",
                Result = newRecord!,
            };
        }
        catch (Exception ex)
        {
            return new Response
            {
                IsSuccess = false,
                Message = ex.Message,
            };
        }
    }



    public async Task<User> GetUserByEMail(
      string urlBase,
      string servicePrefix,
      string controller,
      string email,
      string tokenType,
      string accessToken)
    {
        try
        {
            var model = new UserRequest
            {
                Email = email,
            };

            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(
                request,
                Encoding.UTF8,
                "application/json");

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(tokenType, accessToken);
            client.BaseAddress = new Uri(urlBase);
            var url = string.Format("{0}{1}", servicePrefix, controller);
            var response = await client.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
            {
                return null!;
            }

            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(result)!;
        }
        catch
        {
            return null!;
        }
    }

    public async Task<Response> Put<T>(
        string urlBase,
        string servicePrefix,
        string controller,
        string tokenType,
        string accessToken,
        T model)
    {
        try
        {
            var request = JsonConvert.SerializeObject(model);
            var content = new StringContent(
                request,
                Encoding.UTF8, "application/json");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(tokenType, accessToken);
            client.BaseAddress = new Uri(urlBase);
            var url = string.Format(
                "{0}{1}/{2}",
                servicePrefix,
                controller,
                model!.GetHashCode());
            var response = await client.PostAsync(url, content);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<Response>(result);
                error!.IsSuccess = false;
                return error;
            }

            var newRecord = JsonConvert.DeserializeObject<T>(result);

            return new Response
            {
                IsSuccess = true,
                Result = newRecord!,
            };
        }
        catch (Exception ex)
        {
            return new Response
            {
                IsSuccess = false,
                Message = ex.Message,
            };
        }
    }

    public async Task<Response> Delete<T>(
        string urlBase,
        string servicePrefix,
        string controller,
        string tokenType,
        string accessToken,
        T model)
    {
        try
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(urlBase);
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(tokenType, accessToken);
            var url = string.Format(
                "{0}{1}/{2}",
                servicePrefix,
                controller,
                model!.GetHashCode());
            var response = await client.DeleteAsync(url);
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<Response>(result);
                error!.IsSuccess = false;
                return error;
            }

            return new Response
            {
                IsSuccess = true,
            };
        }
        catch (Exception ex)
        {
            return new Response
            {
                IsSuccess = false,
                Message = ex.Message,
            };
        }
    }

}
