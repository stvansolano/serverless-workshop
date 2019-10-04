
## Requisites

1) Install Node
2) Install Docker Desktop
3) Install VS Code
4) Install VS Code extension: Docker or Docker explorer

## Getting started - Hello Serverless

1) Install Azure Functions Core Tools: 

https://github.com/Azure/azure-functions-core-tools

2) Init the function (choose Node->JavaScript)

func init MyToDoList --docker

3) Change Hello/function.json to be       

`"authLevel": "anonymous",`

4) CD to folder and create new (HTTP trigger) and provide a name `Hello`

`cd`
`func new`

5) Docker build & run

`docker build --rm -f "javascript/MyToDoList/Dockerfile" -t mytodo-serverless:latest javascript/MyToDoList`

`docker run -p 8080:80`

6) Optionally: Start the function locally

`func start --build`

## RESTful-styled Serverless