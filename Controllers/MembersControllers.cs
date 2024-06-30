using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;
using GYMMVC.Models;
using Microsoft.AspNetCore.ResponseCaching;
using Microsoft.AspNetCore.SignalR;
using System.CodeDom.Compiler;



namespace GYMMVC.Controllers
{
    public class MembersController : Controller
    {
        public string uriBase ="ftp://gym.somee.com/www.Gym.somee.com";
        
        [HttpGet]
        public ActionResult Index()
        {
            return View("Cadastrar Membro");
        }

        [HttpPost]
        public async Task<ActionResult> RegistrarAsync(MembersViewModel u)
        {
            try 
            { // codigos aqui

                [HttpGet]
                public async Task<ActionResult> DeleteAsync(int? id)
                {
                    try
                    {
                        HttpClient httpClient = new HttpClient();
                        string token = HttpContext.Session.GetString("SessionTokenMembers");
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token)

                        HttpResponseMessage response = await httpClient.DeleteAsync(uriBase + id.ToString);                        
                        string serialized = await response.Content.ReadAsStringAsync();
                        
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            TempData["Mensagem"] = string.Format("Membro Id {0} removuido com sucesso!", id);
                            return RedirectToAction("Index");
                        }
                        else 
                            throw new System.Exception(serialized);
                    }
                    catch (System.Exception ex)
                    {
                        TempData["MensagemErro"] = ex.Message;
                        return RedirectToAction("Index");
                    }
                }


                [HttpGet]
                public async Task<ActionResult> EditAsync(int? id)
                {
                    try
                    {
                        HttpClient httpClient = new HttpClient();
                        string token = HttpContext.Session.GetString("SessionTokenMember");
                                
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        var content = new StringContent(JsonConvert.SerializeObject(p));
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        HttpResponseMessage response = await httpClient.PutAsync(uriBase + id.ToString);                        
                        string serialized = await response.Content.ReadAsStringAsync();

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            TempData["Mensagem"]=
                                string.Format("Membro {0}, classe {1} atualizado com sucesso!", p.Nome, p.Classe);
                        }
                        else 
                            throw new System.Exception(serialized);
                    }
                    catch (System.Exception ex)
                    {
                        TempData["MensagemErro"] = ex.Message;
                        return RedirectToAction("Index");
                    }
                }


                [HttpGet]
                public async Task<ActionResult> EditAsync(int? id)
                {
                    try
                    {
                        HttpClient httpClient = new HttpClient();
                        string token = HttpContext.Session.GetString("SessionTokenMember");
                        
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        HttpResponseMessage response = await httpClient.GetAsync(uriBase + id.ToString);
                        
                        string serialized = await response.Content.ReadAsStringAsync();

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            MembersViewModel p = await Task.Run(() =>
                            JsonConvert.DeserializeObject<MembersViewModel>(serialized));
                            return View(p);
                        }
                        else 
                            throw new System.Exception(serialized);
                    }
                    catch (System.Exception ex)
                    {
                        TempData["MensagemErro"] = ex.Message;
                        return RedirectToAction("Index");
                    }
                }

                [HttpPost] 
                public ActionResult Create()
                {
                    return View();
                }


                [HttpGet]
                public async Task<ActionResult> DetailsAsync(int? id)
                {
                    try
                    {
                        HttpClient httpClient = new HttpClient();
                        string token = HttpContext.Session.GetString("SessionTokenMember");
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                        HttpResponseMessage response = await httpClient.GetAsync(uriBase + id.ToString);
                        string serialized = await response.Content.ReadAsStringAsync();

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            MembersViewModel p = await Task.Run(() =>
                            JsonConvert.DeserializeObject<MembersViewModel>(serialized));
                            return View(p);
                        }
                        else 
                            throw new System.Exception(serialized);
                    }
                    catch (System.Exception ex)
                    {
                        TempData["MensagemErro"] = ex.Message;
                        return RedirectToAction("Index");
                    }
                }

                [HttpPost] 
                public ActionResult Create()
                {
                    return View();
                }


                [HttpGet]
                public async Task<ActionResult> CreateAsync(MembersViewModel p)
                {
                    try
                    {
                        HttpClient httpClient = new HttpClient();
                        string token = HttpContext.Session.GetString("SessionTokenMembers");
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        var content = new StringContent(JsonConvert.SerializeObject(p));
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        HttpResponseMessage response = await httpClient.PostAsync(uriBase, content);

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            TempData["Mensagem"] = string.Format("Mmebro {0}, Id {1} salvo com sucesso!", p.Nome, serialized);
                            return RedirectToAction("Index");
                        }
                        else
                            throw new System.Exception(serialized);
                    }
                    catch (System.Exception ex) 
                    {
                        TempData["MensagemErro"] = ex.Message;
                        return RedirectToAction("Create");
                    }
                }




                [HttpGet]
                public async Task<ActionResult> IndexAsync()
                {
                    try
                    {
                        string uriComplementar = "GetAll";
                        HttpClient httpClient = new HttpClient();
                        string token = HttpContext.Session.GetString("SessionTokenMembers");
                        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                        HttpResponseMessage response = await httpClient.GetAsync(uriBase + uriComplementar);
                        string serialized = await response.Content.ReadAsStringAsync();

                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            List<MembersViewModel> listamembers = await Task.Run(() =>
                                JsonConvert.DeserializeObject<List<MembersViewModel>>(serialized));
                            
                            return View(listamembers);
                        }
                        else
                            throw new System.Exception(serialized);
                    }
                    catch (System.Exception ex)
                    {
                        TempData["MensagemErro"] = ex.Message;
                        return RedirectToAction("Index");
                    }
                }
                
                [HttpGet]
                public ActionResult IndexLogin()
                {
                    return View("AuthentificarMembers");
                }

                [HttpPost]
                public async Task<ActionResult> AutentificarAsync(MembersViewModel u)
                {
                    try
                    { //CODIGO AQUI
                        HttpClient httpClient = new HttpClient();
                        string uriComplementar = "Autenticar";

                        var content = new StringContent(JsonConvert.SerializeObject(u));
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

                        string serialized = await response.Content.ReadAsStringAsync();

                        if (response.StatusCode == System.Net.HttpStatusCode.OK )
                        {
                            MembersViewModel uLogado = JsonConvert.DeserializeObject<MembersViewModel>(serialized);
                            HttpContext.Session.SetString("SessionTokenMembers", uLogado.Token);
                            TempData["Mensagem"] = string.Format("Bem-vindo {0}!!!", uLogado.Username);
                            return RedirectToAction("Index", "Members");
                        }
                        else
                        {
                            throw new System.Exception(serialized);
                        }
                    }
                    catch(System.Exception ex)
                    {
                        TempData["MensagemErro"] = ex.Message;
                        return IndexLogin();
                    }
                }


                HttpClient httpClient = new HttpClient();
                string uriComplementar = "Registrar";

                var content = new StringContent(JsonConvert.SerializeObject(u));
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/jsaon");
                HttpResponseMessage response = await httpClient.PostAsync(uriBase + uriComplementar, content);

                string serialized = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    TempData["Mensagem"] =
                        string.Format("Membro {0} Registrado com sucesso! Faça o Login para acessar.", u.Username);
                    return View("AutenticarMembro");
                }
                else
                {
                    throw new System.Exception(serialized);
                }

                
                
            }//codigo acima
            catch(System.Exception ex)
            {
                TempData["MensagemErro"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}