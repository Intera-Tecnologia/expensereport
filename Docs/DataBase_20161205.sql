USE [ExpenseReport]
GO
/****** Object:  Table [dbo].[Colaborador]    Script Date: 05/12/2016 16:53:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Colaborador](
	[ColaboradorID] [bigint] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Senha] [varchar](200) NOT NULL,
 CONSTRAINT [PK_Colaborador] PRIMARY KEY CLUSTERED 
(
	[ColaboradorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[FonteDespesa]    Script Date: 05/12/2016 16:53:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[FonteDespesa](
	[FonteDespesaID] [bigint] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
 CONSTRAINT [PK_FonteDespesa] PRIMARY KEY CLUSTERED 
(
	[FonteDespesaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Imagem]    Script Date: 05/12/2016 16:53:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Imagem](
	[ImagemID] [bigint] IDENTITY(1,1) NOT NULL,
	[NomeArquivo] [varchar](100) NOT NULL,
	[RelatorioDespesaID] [bigint] NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Projeto]    Script Date: 05/12/2016 16:53:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Projeto](
	[ProjetoID] [bigint] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
	[Programa] [varchar](100) NOT NULL,
	[CentroDeCusto] [varchar](100) NULL,
	[Status] [varchar](1) NOT NULL,
 CONSTRAINT [PK_Projeto] PRIMARY KEY CLUSTERED 
(
	[ProjetoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Relatorio]    Script Date: 05/12/2016 16:53:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Relatorio](
	[RelatorioID] [bigint] IDENTITY(1,1) NOT NULL,
	[DataEntrega] [datetime] NOT NULL,
	[DiariasRecebidas] [numeric](10, 2) NOT NULL,
	[AdiantamentoRecebido] [numeric](10, 2) NOT NULL,
	[CambioDia] [numeric](10, 2) NOT NULL,
	[Moeda] [varchar](3) NOT NULL,
	[PassagemFaturada] [numeric](10, 2) NULL,
	[ColaboradorID] [bigint] NOT NULL,
	[ViagemID] [bigint] NOT NULL,
 CONSTRAINT [PK_Relatorio] PRIMARY KEY CLUSTERED 
(
	[RelatorioID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RelatorioDespesa]    Script Date: 05/12/2016 16:53:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RelatorioDespesa](
	[RelatorioDespesaID] [bigint] IDENTITY(1,1) NOT NULL,
	[RelatorioID] [bigint] NOT NULL,
	[FonteDespesaID] [bigint] NOT NULL,
	[TipoDespesaID] [bigint] NOT NULL,
	[Descricao] [varchar](300) NOT NULL,
	[Data] [datetime] NOT NULL,
	[Valor] [numeric](10, 2) NOT NULL,
	[Faturado] [bit] NOT NULL,
 CONSTRAINT [PK_RelatorioDespesa] PRIMARY KEY CLUSTERED 
(
	[RelatorioDespesaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TipoDespesa]    Script Date: 05/12/2016 16:53:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TipoDespesa](
	[TipoDespesaID] [bigint] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
 CONSTRAINT [PK_TipoDespesa] PRIMARY KEY CLUSTERED 
(
	[TipoDespesaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Viagem]    Script Date: 05/12/2016 16:53:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Viagem](
	[ViagemID] [bigint] IDENTITY(1,1) NOT NULL,
	[Descricao] [varchar](100) NOT NULL,
	[Justificativa] [varchar](max) NULL,
	[DataInicio] [datetime] NOT NULL,
	[DataFim] [datetime] NOT NULL,
	[ProjetoID] [bigint] NOT NULL,
 CONSTRAINT [PK_Viagem] PRIMARY KEY CLUSTERED 
(
	[ViagemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[FonteDespesa] ON 

INSERT [dbo].[FonteDespesa] ([FonteDespesaID], [Descricao]) VALUES (1, N'Cartão')
INSERT [dbo].[FonteDespesa] ([FonteDespesaID], [Descricao]) VALUES (2, N'Dinheiro')
SET IDENTITY_INSERT [dbo].[FonteDespesa] OFF
SET IDENTITY_INSERT [dbo].[TipoDespesa] ON 

INSERT [dbo].[TipoDespesa] ([TipoDespesaID], [Descricao]) VALUES (1, N'Diária')
INSERT [dbo].[TipoDespesa] ([TipoDespesaID], [Descricao]) VALUES (2, N'Transporte')
INSERT [dbo].[TipoDespesa] ([TipoDespesaID], [Descricao]) VALUES (3, N'Representação')
INSERT [dbo].[TipoDespesa] ([TipoDespesaID], [Descricao]) VALUES (4, N'Hospedagem')
INSERT [dbo].[TipoDespesa] ([TipoDespesaID], [Descricao]) VALUES (5, N'Cargas')
INSERT [dbo].[TipoDespesa] ([TipoDespesaID], [Descricao]) VALUES (6, N'Outras')
SET IDENTITY_INSERT [dbo].[TipoDespesa] OFF
ALTER TABLE [dbo].[Projeto] ADD  CONSTRAINT [DF_Projeto_Status]  DEFAULT ('A') FOR [Status]
GO
ALTER TABLE [dbo].[Relatorio] ADD  CONSTRAINT [DF_Relatorio_DiariasRecebidas]  DEFAULT ((0)) FOR [DiariasRecebidas]
GO
ALTER TABLE [dbo].[Relatorio] ADD  CONSTRAINT [DF_Relatorio_AdiantamentoRecebido]  DEFAULT ((0)) FOR [AdiantamentoRecebido]
GO
ALTER TABLE [dbo].[Relatorio] ADD  CONSTRAINT [DF_Relatorio_Moeda]  DEFAULT ('BRL') FOR [Moeda]
GO
ALTER TABLE [dbo].[RelatorioDespesa] ADD  CONSTRAINT [DF_RelatorioDespesa_Faturado]  DEFAULT ((0)) FOR [Faturado]
GO
ALTER TABLE [dbo].[Imagem]  WITH CHECK ADD  CONSTRAINT [FK_Imagem_RelatorioDespesa] FOREIGN KEY([RelatorioDespesaID])
REFERENCES [dbo].[RelatorioDespesa] ([RelatorioDespesaID])
GO
ALTER TABLE [dbo].[Imagem] CHECK CONSTRAINT [FK_Imagem_RelatorioDespesa]
GO
ALTER TABLE [dbo].[Relatorio]  WITH CHECK ADD  CONSTRAINT [FK_Relatorio_Colaborador] FOREIGN KEY([ColaboradorID])
REFERENCES [dbo].[Colaborador] ([ColaboradorID])
GO
ALTER TABLE [dbo].[Relatorio] CHECK CONSTRAINT [FK_Relatorio_Colaborador]
GO
ALTER TABLE [dbo].[Relatorio]  WITH CHECK ADD  CONSTRAINT [FK_Relatorio_Viagem] FOREIGN KEY([ViagemID])
REFERENCES [dbo].[Viagem] ([ViagemID])
GO
ALTER TABLE [dbo].[Relatorio] CHECK CONSTRAINT [FK_Relatorio_Viagem]
GO
ALTER TABLE [dbo].[RelatorioDespesa]  WITH CHECK ADD  CONSTRAINT [FK_RelatorioDespesa_FonteDespesa] FOREIGN KEY([FonteDespesaID])
REFERENCES [dbo].[FonteDespesa] ([FonteDespesaID])
GO
ALTER TABLE [dbo].[RelatorioDespesa] CHECK CONSTRAINT [FK_RelatorioDespesa_FonteDespesa]
GO
ALTER TABLE [dbo].[RelatorioDespesa]  WITH CHECK ADD  CONSTRAINT [FK_RelatorioDespesa_Relatorio] FOREIGN KEY([RelatorioID])
REFERENCES [dbo].[Relatorio] ([RelatorioID])
GO
ALTER TABLE [dbo].[RelatorioDespesa] CHECK CONSTRAINT [FK_RelatorioDespesa_Relatorio]
GO
ALTER TABLE [dbo].[RelatorioDespesa]  WITH CHECK ADD  CONSTRAINT [FK_RelatorioDespesa_TipoDespesa] FOREIGN KEY([TipoDespesaID])
REFERENCES [dbo].[TipoDespesa] ([TipoDespesaID])
GO
ALTER TABLE [dbo].[RelatorioDespesa] CHECK CONSTRAINT [FK_RelatorioDespesa_TipoDespesa]
GO
ALTER TABLE [dbo].[Viagem]  WITH CHECK ADD  CONSTRAINT [FK_Viagem_Projeto] FOREIGN KEY([ProjetoID])
REFERENCES [dbo].[Projeto] ([ProjetoID])
GO
ALTER TABLE [dbo].[Viagem] CHECK CONSTRAINT [FK_Viagem_Projeto]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'A - Aberto, E - Encerrado' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Projeto', @level2type=N'COLUMN',@level2name=N'Status'
GO
