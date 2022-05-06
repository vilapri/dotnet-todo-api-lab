provider "azurerm" {
  features {}
}

resource "azurerm_resource_group" "sffrg1" {
  name     = "sffrg1"
  location = "West Europe"
}

resource "azurerm_service_plan" "spg1" {
  name                = "spg1"
  resource_group_name = azurerm_resource_group.sffrg1.name
  location            = azurerm_resource_group.sffrg1.location
  os_type             = "Linux"
  sku_name            = "B1"
}

resource "azurerm_linux_web_app" "webappsffrg1" {
  name                = "webappsffrg1"
  resource_group_name = azurerm_resource_group.sffrg1.name
  location            = azurerm_service_plan.spg1.location
  service_plan_id     = azurerm_service_plan.spg1.id

  site_config { 
      application_stack {
          dotnet_version = "6.0"
      }
  }
}
