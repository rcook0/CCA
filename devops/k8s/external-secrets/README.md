# Secret Providers: Options Matrix

You have three secure patterns to manage secrets:

1) External Secrets Operator (recommended for cloud vaults)
   - AWS Secrets Manager: see clustersecretstore.yaml (default)
   - GCP Secret Manager: clustersecretstore-gcp.yaml
   - Azure Key Vault: clustersecretstore-azure.yaml
   Apply one ClusterSecretStore, and use externalsecret.yaml to map keys:
     kubectl apply -f clustersecretstore-<provider>.yaml
     kubectl apply -f externalsecret.yaml

2) Sealed Secrets (gitops-friendly)
   - Encrypt a Secret into a SealedSecret with 'kubeseal'.
   - Commit the SealedSecret manifest safely.

3) Helm fallback Secret (dev only)
   - Set 'secrets.useExternal=false' in Helm values.
   - Values from 'secrets.fallback.*' render a native Secret.

API reads from Secret name set in 'values.yaml' → .Values.secrets.name (default: mycca-secrets).
