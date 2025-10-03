import { test, expect } from '@playwright/test';

test('role-based redirect after login', async ({ page }) => {
  await page.goto('/');
  // Assuming Keycloak login page is shown and test realm has a user
  // Replace selectors with your theme specifics
  await page.fill('input[name="username"]', process.env.E2E_USER || 'student@example.com');
  await page.fill('input[name="password"]', process.env.E2E_PASS || 'Password123!');
  await page.click('button:has-text("Sign In"), input[type="submit"]');
  await page.waitForURL('**/student/dashboard', { timeout: 15000 });
  await expect(page).toHaveURL(/student\/dashboard/);
});
