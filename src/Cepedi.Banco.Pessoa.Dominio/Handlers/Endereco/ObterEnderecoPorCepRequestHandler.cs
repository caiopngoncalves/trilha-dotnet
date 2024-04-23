using Cepedi.Banco.Pessoa.Compartilhado.Requests;
using Cepedi.Banco.Pessoa.Compartilhado.Responses;
using Cepedi.Banco.Pessoa.Dominio.Repository;
using MediatR;
using Microsoft.Extensions.Logging;
using OperationResult;

namespace Cepedi.Banco.Pessoa.Dominio.Handlers;

public class ObterEnderecoPorCepRequestHandler : IRequestHandler<ObterEnderecoPorCepRequest, Result<ObterEnderecoPorCepResponse>>
{
    private readonly IEnderecoRepository _enderecoRepository;
    private readonly ILogger<ObterEnderecoPorCepRequestHandler> _logger;
    public ObterEnderecoPorCepRequestHandler(IEnderecoRepository enderecoRepository, ILogger<ObterEnderecoPorCepRequestHandler> logger)
    {
        _enderecoRepository = enderecoRepository;
        _logger = logger;
    }
    public async Task<Result<ObterEnderecoPorCepResponse>> Handle(ObterEnderecoPorCepRequest request, CancellationToken cancellationToken)
    {
        //var endereco = await _enderecoRepository.ObterEnderecoPorCepAsync(request.Cep);

        var verificarCep = new VerificarCep();
        var enderecoApi = await verificarCep.GetEndereço(request.Cep);
        return Result.Success(new ObterEnderecoPorCepResponse()
        {
            Cep = enderecoApi.cep,
            Logradouro = enderecoApi.logradouro,
            Complemento = enderecoApi.complemento,
            Bairro = enderecoApi.bairro,
            Cidade = enderecoApi.localidade,
            Uf = enderecoApi.uf,
            Pais = "Brasil",
            Numero = "0"
        });
    }


}
