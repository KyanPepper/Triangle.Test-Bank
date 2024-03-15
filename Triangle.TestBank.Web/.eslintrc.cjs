module.exports = {
  root: true,
  env: {
    node: true,
  },
  extends: [
    "plugin:vue/vue3-essential",
    "eslint:recommended",
    "@vue/eslint-config-typescript",
  ],
  parserOptions: {
    ecmaVersion: "latest",
  },
  rules: {
    "vue/multi-word-component-names": "off",
    "no-debugger": process.env.NODE_ENV === "production" ? "warn" : "off",
    "no-console": "off",
    "no-undef": "off", // Redundant with Typescript
  },
  ignorePatterns: ["wwwroot", "node_modules", "/**/*.g.ts"],
};
