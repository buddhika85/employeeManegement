using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using viewModels.employeeManagement;

namespace employeeManagement.Models.ServiceConsumer
{
    public class RestSharpServiceConsumer<TEntity> where TEntity : class
    {        
        string serviceUrl = null;
        RestClient restClient = null;

        public RestSharpServiceConsumer(string serviceUrl)
        {
            string baseUrl = ConfigurationManager.AppSettings["apiBaseUrl"];
            this.serviceUrl = serviceUrl;
            this.restClient = new RestClient()
                                {
                                    BaseUrl = new Uri(baseUrl)
                                };
        }

        // Get all
        public IList<TEntity> GetAll()
        {
            try
            {
                var request = new RestRequest(serviceUrl, Method.GET)
                                {
                                    RequestFormat = DataFormat.Json
                                };
                var response = restClient.Execute(request);
                if (response.Content != null)
                {
                    IList<TEntity> entities = JsonConvert.DeserializeObject<IList<TEntity>>(response.Content);
                    return entities;
                }
                else
                {
                    throw response.ErrorException;
                }
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
        }

        public TEntity GetById()
        {
            try
            {
                var request = new RestRequest(serviceUrl, Method.GET)
                {
                    RequestFormat = DataFormat.Json
                };
                //request.AddParameter("id", id, ParameterType.UrlSegment);
                var response = restClient.Execute(request);
                if (response.Content != null)
                {
                    TEntity entity = JsonConvert.DeserializeObject<TEntity>(response.Content);
                    return entity;
                }
                else
                {
                    throw response.ErrorException;
                }
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
        }

        public bool Inert(EmployeeViewModel employeeVm)
        {
            try
            {
                var request = new RestRequest(serviceUrl, Method.PUT)
                {
                    RequestFormat = DataFormat.Json
                };
                request.AddParameter("viewModel", employeeVm, ParameterType.UrlSegment);
                request.AddBody(employeeVm);
                var response = restClient.Execute(request);
                if (response.Content != null)
                {
                    bool isInserted = JsonConvert.DeserializeObject<bool>(response.Content);
                    return isInserted;
                }
                else
                {
                    throw response.ErrorException;
                }
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
        }

        public bool Update(EmployeeViewModel employeeVm)
        {
            try
            {
                var request = new RestRequest(serviceUrl, Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                request.AddParameter("viewModel", employeeVm, ParameterType.UrlSegment);
                request.AddBody(employeeVm);
                var response = restClient.Execute(request);
                if (response.Content != null)
                {
                    bool isUpdated = JsonConvert.DeserializeObject<bool>(response.Content);
                    return isUpdated;
                }
                else
                {
                    throw response.ErrorException;
                }
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var request = new RestRequest(serviceUrl, Method.DELETE)
                {
                    RequestFormat = DataFormat.Json
                };
                //request.AddParameter("id", id, ParameterType.UrlSegment);
                //request.AddBody(id);
                var response = restClient.Execute(request);
                if (response.Content != null)
                {
                    bool isDeleted = JsonConvert.DeserializeObject<bool>(response.Content);
                    return isDeleted;
                }
                else
                {
                    throw response.ErrorException;
                }
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
        }

        // Get by Id
        // Insert
        // Update
        // Delete
    }
}