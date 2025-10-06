import { test, expect } from '@playwright/test';

test('role-based redirect after login (placeholder)', async ({ page }) => {
  await page.goto('/');
  // TODO: implement actual login once Keycloak test user is available
  await expect(page).toHaveURL(/\//);
});
