using System.Net;
using System.Text.Json;

public class VerificarCep{
    public async Task<EnderecoResult> GetEndereço(string cep){
        string url = $"https://viacep.com.br/ws/{cep}/json";
        var httpCLient = new HttpClient();
        var response = await httpCLient.GetAsync(url);
        if(!response.IsSuccessStatusCode){
            throw new Exception ("Erro ao verificar cep");
        }
        var responseContet = await response.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<EnderecoResult>(responseContet);
        return result!;
    }
}

public class EnderecoResult {
    public string cep {get; set;}
    public string logradouro {get; set;}
    public string complemento {get; set;}
    public string bairro {get; set;}
    public string localidade {get; set;}
    public string uf {get; set;}
    public string ibge {get; set;}
    public string gia {get; set;}
    public string ddd {get; set;}
    public string siafi {get; set;}
}