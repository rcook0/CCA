import { I18nProvider } from "../i18n/provider";

export default function App({ Component, pageProps }) {
  return (
    <I18nProvider locale="en">
      <Component {...pageProps} />
    </I18nProvider>
  );
}
