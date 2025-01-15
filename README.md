<p align="center">
  <img src="https://github.com/J4ron/HelperHub/blob/master/assets/LogoHHub.png" width="550"/>
</p>
<p align="center">
  <img src="https://github.com/J4ron/HelperHub/blob/master/assets/demo.png">
</p>

## Demo

url: https://helperhub.skeptic-systems.de/

## Install

Docker

nano docker-compose.yml

copy the offical docker-compose.yml content from the repository to your local docker-compose.yml file

Adjust path and post settings

docker compose up -d

## Configuration

You can adjust the data path in the docker-compose.yml

## Additional Information

The URL is hard-coded under `/RFE/Components/Pages/Home.razor`. In the future, this will be changed dynamically using the Docker Env variable `API__URL:`, but that is beyond my knowledge. We are open to suggestions. Otherwise, you have to change the 3 API URLs in the path mentioned above and build the Docker image yourself.

## Docker Image

https://hub.docker.com/repository/docker/skepticsystems/helper-hub/general

[![AGPL License](https://img.shields.io/badge/license-AGPL-blue.svg)](http://www.gnu.org/licenses/agpl-3.0)
