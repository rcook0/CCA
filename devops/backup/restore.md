# Postgres Backup/Restore

## Backup (Compose)
Mount `./backups` and run:
```bash
docker compose run --rm -e PGPASSWORD=postgres -v $(pwd)/backups:/backups   postgres:15 bash -lc "/backups/pg_backup.sh"
```

## Restore
```bash
docker compose exec postgres bash -lc "pg_restore -h localhost -U postgres -d mycca /backups/<file>.dump"
```
