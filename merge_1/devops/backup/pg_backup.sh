#!/usr/bin/env bash
set -euo pipefail
: "${PGHOST:=postgres}"
: "${PGPORT:=5432}"
: "${PGUSER:=postgres}"
: "${PGPASSWORD:=postgres}"
: "${PGDATABASE:=mycca}"
STAMP=$(date +%Y%m%d%H%M%S)
mkdir -p /backups
pg_dump -h "$PGHOST" -p "$PGPORT" -U "$PGUSER" -F c -d "$PGDATABASE" -f "/backups/${PGDATABASE}_${STAMP}.dump"
echo "Backup created: /backups/${PGDATABASE}_${STAMP}.dump"
