# Keycloak Realm Import (Compose-first)

This repo includes a realm export at `devops/keycloak/realm/mycca-realm.json`.
In Docker Compose, Keycloak will start with `--import-realm` and load this file.

- Roles: admin, advisor, participant (+ composite legacy: student→participant, counselor→advisor)
- Default Group: ORG_DEFAULT (attribute: org_id = 00000000-0000-0000-0000-000000000001)
- Protocol Mapper: `org_id` into tokens (access/id/userinfo)

Credentials (dev only): set `KEYCLOAK_ADMIN` / `KEYCLOAK_ADMIN_PASSWORD` in `.env`.
