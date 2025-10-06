# Makefile for MyCCA Identity System

DOCKER_COMPOSE = docker-compose

up:
	$(DOCKER_COMPOSE) up -d

down:
	$(DOCKER_COMPOSE) down

logs:
	$(DOCKER_COMPOSE) logs -f

build:
	$(DOCKER_COMPOSE) build

rebuild: down build up

ps:
	$(DOCKER_COMPOSE) ps

prometheus:
	open http://localhost:9090

grafana:
	open http://localhost:3001
