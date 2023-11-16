Clear-Host

CHCP 65001

# Defina a variável de ambiente LANG para UTF-8
$env:LANG = "en_US.UTF-8"

# Obtém o diretório do script atual
$scriptDir = $PSScriptRoot

# Define o diretório para o diretório do script
Set-Location $scriptDir

# Obtém o diretório pai do diretório do script
$parentDir = Split-Path -Path $scriptDir -Parent

# Crie uma marca de data e hora para os nomes de arquivo únicos
$timestamp = Get-Date -Format "yyyyMMdd_HHmmss"

# Define o caminho de saída usando o diretório pai e a marca de data e hora
$outputPath = Join-Path -Path $parentDir -ChildPath "SQL\"

# Especifique o caminho para o arquivo de log com a marca de data e hora
$logFilePath = Join-Path -Path $parentDir -ChildPath "LOGs\transcript_$timestamp.log"


# *************************************************** #


# Inicie o transcript para gravar a saída do console
Start-Transcript -Path $logFilePath

# Agora $outputPath contém o caminho desejado
Write-Host "Script Directory: $scriptDir"
Write-Host "Caminho de Saída: $outputPath"
Write-Host "Caminho do transcript: $logFilePath"


# Check if the directory exists before removing
if (Test-Path $outputPath)
{
    Remove-Item $outputPath -Recurse -Force
}


if (Test-Path .\Migrations\)
{
    Remove-Item .\Migrations\ -Recurse -Force
}


# *************************************************** #


# instalar dot net entity framework e o codegenerator para os controladores
dotnet tool install dotnet-ef
dotnet tool update  dotnet-ef

dotnet tool install dotnet-aspnet-codegenerator
dotnet tool update  dotnet-aspnet-codegenerator

dotnet tool install dotnet-ef
dotnet tool update  dotnet-ef

dotnet add package Microsoft.EntityFrameworkCore.Design


# instalar dot net entity framework e o codegenerator para os controladores
dotnet tool install --global dotnet-ef
dotnet tool update  --global dotnet-ef

dotnet tool install --global dotnet-aspnet-codegenerator
dotnet tool update  --global dotnet-aspnet-codegenerator

dotnet tool install --global dotnet-ef
dotnet tool update  --global dotnet-ef

dotnet add package Microsoft.EntityFrameworkCore.Design


# creating migrations for the datacontext

# dotnet ef migrations add InitDB   --context DataContextMySQL
# dotnet ef migrations script       --context DataContextMySQL   --output $outputPath\script_MySQL_$timestamp.sql
# dotnet ef database   drop         --context DataContextMySQL   --force
# dotnet ef database   update       --context DataContextMySQL
# dotnet ef dbcontext  info         --context DataContextMySQL
# dotnet ef dbcontext  optimize     --context DataContextMySQL
Start-Sleep 3


# dotnet ef migrations add InitDB   --context DataContextSqLite
# dotnet ef migrations script       --context DataContextSqLite  --output $outputPath\script_SQLite_$timestamp.sql
# dotnet ef database   drop         --context DataContextSqLite  --force
# dotnet ef database   update       --context DataContextSqLite
# dotnet ef dbcontext  info         --context DataContextSqLite
#dotnet ef dbcontext  optimize     --context DataContextSqLite
Start-Sleep 3


# dotnet ef migrations add InitDB   --context DataContextMsSql
# dotnet ef migrations script       --context DataContextMsSql   --output $outputPath\script_MsSql_$timestamp.sql
# dotnet ef database   drop         --context DataContextMsSql   --force
# dotnet ef database   update       --context DataContextMsSql
# dotnet ef dbcontext  info         --context DataContextMsSql
# dotnet ef dbcontext  optimize     --context DataContextMsSql
# Start-Sleep 3


dotnet ef migrations add InitDB   --context ApplicationDbContext
dotnet ef migrations script       --context ApplicationDbContext  --output $outputPath\script_MySql_$timestamp.sql
dotnet ef database   drop         --context ApplicationDbContext  --force
dotnet ef database   update       --context ApplicationDbContext
dotnet ef dbcontext  info         --context ApplicationDbContext
dotnet ef dbcontext  optimize     --context ApplicationDbContext
Start-Sleep 3


dotnet ef dbcontext  list
Start-Sleep 3


# Encerre o transcript para parar a gravação
Stop-Transcript

