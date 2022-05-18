1. az login
2. az account list
3. az account set --subscription cb1820be-b01a-46c6-9b8f-7937db13b16a
4. follow linux webapp deployment
https://registry.terraform.io/providers/hashicorp/azurerm/latest/docs/resources/linux_web_app
5. terraform init
6. terraform plan
7. terraform apply
8. Deploy:
az webapp deployment source config --name sffwebapp --resource-group sffdotnetapirg --repo-url https://github.com/vilapri/dotnet-todo-api-lab --branch main --manual-integration