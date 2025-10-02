# Sealed Secrets (Bitnami) - Optional
Use Sealed Secrets to store encrypted Kubernetes Secrets in git.

## Quickstart
1) Install controller:
   kubectl apply -f https://github.com/bitnami-labs/sealed-secrets/releases/download/v0.27.2/controller.yaml

2) Create a plain Secret manifest (DO NOT COMMIT real values):
   kubectl -n mycca create secret generic mycca-secrets      --from-literal=KEYCLOAK_CLIENT_SECRET=changeme      --from-literal=SMTP_USERNAME=changeme      --from-literal=SMTP_PASSWORD=changeme      --from-literal=SLACK_WEBHOOK=https://hooks.slack.com/services/XXX/YYY/ZZZ      --from-literal=TEAMS_WEBHOOK=https://outlook.office.com/webhook/your-teams-webhook-url      --dry-run=client -o yaml > mycca-secrets.yaml

3) Seal the secret (requires cluster access):
   kubeseal --format yaml < mycca-secrets.yaml > mycca-sealedsecret.yaml

4) Commit and apply the sealed secret:
   kubectl apply -f mycca-sealedsecret.yaml

The controller will create a runtime Secret named 'mycca-secrets' which the API references via envFrom.
