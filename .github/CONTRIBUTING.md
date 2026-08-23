# Como contribuir com o ElsEvo

## Antes de começar

- Dois canais separados: [`ElsEvo`](https://github.com/AyameJk/ElsEvo)
  (estável) e [`ElsEvoBeta`](https://github.com/AyameJk/ElsEvoBeta) (beta).
  Uma contribuição em um canal não é aplicada automaticamente no outro.
- Para mudanças grandes, abra uma issue antes de investir tempo escrevendo
  código.

## Ambiente local

Requisitos: [.NET 8 SDK](https://dotnet.microsoft.com/download) e
[Inno Setup 6](https://jrsoftware.org/isinfo.php) (só para gerar instalador).

```bash
dotnet build ElsEvo.csproj
```

```bash
dotnet publish ElsEvo.csproj -c Release -r win-x64 --self-contained true -p:PublishSingleFile=true -p:IncludeNativeLibrariesForSelfExtract=true
```

## Convenções

- Nomenclatura em português (ex.: `GerenciadorDeMods`,
  `AplicarTemaSalvo`)
- Texto de interface via `Idiomas.T("Chave")`, nunca string fixa — adicione
  a tradução em PT/EN/ZH
- Não edite `AppVersion.cs` manualmente
- Sem caminhos absolutos da sua máquina
- Elementos visuais novos devem usar os `DynamicResource` do tema
  (`CorFundoPrincipal`, `CorTextoPrimario`, etc.), não cores fixas

## Pull Request

1. Fork e branch a partir da `main`
2. Teste localmente com `dotnet publish`
3. Abra o PR preenchendo o template

## Reportando bugs

Abra uma [issue](https://github.com/AyameJk/ElsEvo/issues) com: o que
esperava, o que aconteceu, passos para reproduzir, print de tela (se visual)
e a versão do ElsEvo usada.
