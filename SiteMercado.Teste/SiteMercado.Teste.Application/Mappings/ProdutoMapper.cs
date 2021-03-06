using AutoMapper;
using SiteMercado.Teste.Application.DTOs.Produto;
using SiteMercado.Teste.Domain.Entities;
using System;

namespace SiteMercado.Teste.Application.Mappings
{
    public static class ProdutoMapper
    {
        public static ProdutoResponse ToProdutoResponse(this Produto entity)
        {
            IMapper mapper = ProdutoToProdutoResponseConfig().CreateMapper();
            return mapper.Map<ProdutoResponse>(entity);
        }

        public static ProdutoViewModel ToProdutoViewModel(this ProdutoResponse response)
        {
            IMapper mapper = ProdutoResponseToProdutoViewModelConfig().CreateMapper();
            return mapper.Map<ProdutoViewModel>(response);
        }

        public static Produto ToProduto(this ProdutoRequest request)
        {
            IMapper mapper = ProdutoToProdutoRequestConfig().CreateMapper();
            return mapper.Map<Produto>(request);
        }

        public static Produto ToProduto(this ProdutoRequest request, Guid id)
        {
            return new Produto(id, request.Nome, request.Valor, request.Imagem);
        }

        #region Configs
        private static MapperConfiguration ProdutoToProdutoResponseConfig()
        {
            return new MapperConfiguration(m =>
            {
                m.CreateMap<Produto, ProdutoResponse>();
                m.CreateMap<ProdutoResponse, Produto>();
            });
        }

        private static MapperConfiguration ProdutoToProdutoRequestConfig()
        {
            return new MapperConfiguration(m =>
            {
                m.CreateMap<Produto, ProdutoRequest>();
                m.CreateMap<ProdutoRequest, Produto>();
            });
        }

        private static MapperConfiguration ProdutoResponseToProdutoViewModelConfig()
        {
            return new MapperConfiguration(m =>
            {
                m.CreateMap<ProdutoResponse, ProdutoViewModel>();
                m.CreateMap<ProdutoViewModel, ProdutoResponse>();
            });
        }
        #endregion
    }
}
