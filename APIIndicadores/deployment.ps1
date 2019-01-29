$dirPublicacao = "publicacao"

# Força a exclusão de uma pasta para publicação criada anteriormente
if (Test-Path $dirPublicacao) {
    Remove-Item -Recurse -Force $dirPublicacao
}

dotnet publish -c release -o $dirPublicacao

$arqPublicacao = "publicacao.zip"
if (Test-Path $arqPublicacao) {
    Remove-Item -Force $arqPublicacao
}

Add-Type -assembly "system.io.compression.filesystem"
[io.compression.zipfile]::CreateFromDirectory($dirPublicacao, $arqPublicacao)

az webapp deployment source config-zip -n "groffeindicadores" -g "groffeindicadores" --src $arqPublicacao