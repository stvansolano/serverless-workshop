

## Getting started - FaaS

### Requisites

- a) Install Node
- b) Install Docker Desktop
- c) Install VS Code
- d) Install VS Code extensions
    - Docker or Docker explorer
    - Azure Functions Extension
- e) Install Azure Functions Core Tools: 
    https://github.com/Azure/azure-functions-core-tools

### NodeJS functions development

1) Init the function (choose Node->JavaScript)

func init MyToDoList --docker

2) Change Hello/function.json to be       

`"authLevel": "anonymous",`

3) CD to folder and create new (HTTP trigger) and provide a name `Hello`

`cd`
`func new`

4) Docker build & run

`docker build --rm -f "javascript/MyToDoList/Dockerfile" -t mytodo-serverless:latest javascript/MyToDoList`

`docker run -p 8080:80`

5) Optionally: Start the function locally

`func start --build`

## Getting Started - Hello Mobile

### Requisites

a) Install ngrok


### NativeScript development
1) Install NativeScript CLI + init template

`npm install -g nativescript`

Then

`$ npm install -g @vue/cli @vue/cli-init`

2) Create a templated-app project

`vue init nativescript-vue/vue-cli-template <project-name>`

3) Go to project, install and run/preview it

- cd MyTodoApp
- npm install
- tns build ios
- tns preview
- tns run android

4) Run ngrok for HTTPS redirects (functions) and consume the endpoint in the VueJS/NativeScript

`./ngrok http 8080 --host-header=localhost:8080`

## NativeScript recommended links:

- [Try it online](https://play.nativescript.org/)
- [Documentation](https://nativescript-vue.org/en/docs/introduction/)

## RESTful-styled Serverless

Install MongoDB (Docker pull)

`docker pull mongo:4.0.4` and
`docker run -d -p 27017-27019:27017-27019 --name mongodb mongo:4.0.4`

Install from VS Code: 
    - Azure Cosmos DB

Go to Azure extension -> CosmosDB
Attached Databvase Accounts -> Attach Database Account

mongodb://127.0.0.1:27017

## Other Docker commands

`docker system prune`

## Functions reference

[Azure Functions - Node](https://docs.microsoft.com/en-us/azure/azure-functions/functions-reference-node)
```
FunctionApp
 | - host.json
 | - myNodeFunction
 | | - function.json
 | - lib
 | | - sayHello.js
 | - node_modules
 | | - ... packages ...
 | - package.json
```

### Docker documentation
- [Docker Compose enviroment variables](https://docs.docker.com/compose/environment-variables/)

### Publish functions

`func azure functionapp publish <YourFunctionAppName> --publish-local-settings -i --overwrite-settings -y`