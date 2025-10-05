import React, { createContext, useContext, useMemo } from "react";
import en from "./en.json";

const dictionaries = { en };
const I18nCtx = createContext({ t: (k) => k });

export function I18nProvider({ locale = "en", children }) {
  const dict = dictionaries[locale] || dictionaries.en;
  const t = useMemo(() => (key) => dict[key] ?? key, [dict]);
  return <I18nCtx.Provider value={{ t }}>{children}</I18nCtx.Provider>;
}

export function useT() {
  return useContext(I18nCtx).t;
}
