
<div align="center">

![Header](https://capsule-render.vercel.app/api?type=waving&color=0078D4&height=200&section=header&text=CLDV6212&fontSize=60&fontColor=white&fontAlignY=35&desc=Cloud%20Development&descAlignY=55&descSize=20&descColor=white)

</div>

## TABLE OF CONTENTS
- [MEMBERS](#members)
- [WHAT EACH MEMBER DID](#what-each-member-did)





![GitHub repo size](https://img.shields.io/github/repo-size/EMECPE/cldv6212-2026-g2-poe-brandon-badenhorst?style=for-the-badge)
![GitHub contributors](https://img.shields.io/github/contributors/EMECPE/cldv6212-2026-g2-poe-brandon-badenhorst?style=for-the-badge)
![GitHub last commit](https://img.shields.io/github/last-commit/EMECPE/cldv6212-2026-g2-poe-brandon-badenhorst?style=for-the-badge)
![Azure](https://img.shields.io/badge/Azure-0078D4?style=for-the-badge&logo=microsoftazure&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2496ED?style=for-the-badge&logo=docker&logoColor=white)
![Postman](https://img.shields.io/badge/Postman-FF6C37?style=for-the-badge&logo=postman&logoColor=white)







| COMMANDS |
| ------------- |
| docker pull brandonbadenhorst/coffeenchill-functions:v1.0 |
| docker pull brandonbadenhorst/azurite:v1.0 |
| docker rm -f coffeenchill-functions|
| docker run -d --name azurite -p 10000:10000 -p 10001:10001 -p 10002:10002 brandonbadenhorst/azurite:v1.0 |
| docker run -d --name coffeenchill-functions -p 7071:80 -e AzureWebJobsStorage="DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;BlobEndpoint=http://host.docker.internal:10000/devstoreaccount1;QueueEndpoint=http://host.docker.internal:10001/devstoreaccount1;TableEndpoint=http://host.docker.internal:10002/devstoreaccount1;" -e FUNCTIONS_WORKER_RUNTIME="dotnet-isolated" brandonbadenhorst/coffeenchill-functions:v1.0 |













| COMMANDS |
| ------------- |
| `docker login` |























































































## MEMBERS
 
| NAME | STUDENT NUMBER |
| ----------- | ----------- |
| Brandon | [ student number asseblief ] |
| Dayyaan | [ student number asseblief ] |
| Oisín | [ student number asseblief ] |
| Tristan | [ student number asseblief ] |


## WHAT EACH MEMBER DID

| MEMBER | USED | RESPONSIBILITIES |
| ------------- | ----------- | ----------- |
| Brandon | - Azurite Containers <br>- Functions Dockerfile <br>- Docker Hub account | running and pushing the dockerfile, function image and confirming that Azureite image works. |
| Dayyaan | - Staff docs File Share/ blob | building the blob storage as well as the 3 functions. |
| Oisín | - MenueItems table <br>- Menu Azure Functions | build the table schema aswell as the 5 menu functions. |
| Tristan | - Postman <br>- README.md <br>- Youtube video | creation of the full postman collection, creating the README as well as doing the walkthrough of the project for the video. |









<div align="center">

![Footer](https://capsule-render.vercel.app/api?type=waving&color=0078D4&height=120&section=footer&text=Made%20by%20Group%202&fontSize=20&fontColor=white&fontAlignY=65)

</div>

</div>
