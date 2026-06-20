module Imported.Src.Context.AuthContextTsx

let file = """import { createContext, useContext, useState, useCallback, useEffect } from 'react';
import type { ReactNode } from 'react';

interface AuthUser {
  userId: string;
  userName: string;
}

interface AuthContextType {
  isAuthenticated: boolean;
  userId: string | null;
  userName: string;
  login: (userId: string) => boolean;
  logout: () => void;
  addUser: (userId: string, userName: string) => boolean;
  listUsers: () => Array<{ userId: string; userName: string }>;
}

const USER_TABLE_B64 = 'eyJVU0VSMDAxIjoiSm9obiBNYXJ0aW5leiIsIlVTRVIwMDIiOiJTYXJhaCBKaG9uc29uIiwiVVNFUjAwMyI6Ik1pY2hhZWwgQ2hlbiIsIlVTRVIwMDQiOiJFbWlsaWEgUm9kcmlndWV6IiwiVVNFUjAwNSI6IkRhdmlkIFRob21wc29uIiwiQURNSU4wMDEiOiJBZG1pbiBVc2VyIn0=';

function decodeUserTable(): Record<string, string> {
  try {
    const json = atob(USER_TABLE_B64);
    return JSON.parse(json) as Record<string, string>;
  } catch {
    return {};
  }
}

function loadUsers(): Record<string, string> {
  const base = decodeUserTable();
  try {
    const extra = localStorage.getItem('turtle_users_extra');
    if (extra) return { ...base, ...JSON.parse(extra) };
  } catch { /* ignore */ }
  return base;
}

let VALID_USERS = loadUsers();

const AuthContext = createContext<AuthContextType>({
  isAuthenticated: false,
  userId: null,
  userName: '',
  login: () => false,
  logout: () => {},
  addUser: () => false,
  listUsers: () => [],
});

export function AuthProvider({ children }: { children: ReactNode }) {
  const [auth, setAuth] = useState<AuthUser | null>(() => {
    try {
      const stored = localStorage.getItem('turtle_auth');
      if (stored) {
        const parsed = JSON.parse(stored) as AuthUser;
        if (VALID_USERS[parsed.userId]) {
          return parsed;
        }
      }
    } catch {
      // ignore parse errors
    }
    return null;
  });

  useEffect(() => {
    if (auth) {
      localStorage.setItem('turtle_auth', JSON.stringify(auth));
    } else {
      localStorage.removeItem('turtle_auth');
    }
  }, [auth]);

  const login = useCallback((userId: string): boolean => {
    const normalizedId = userId.trim().toUpperCase();
    const userName = VALID_USERS[normalizedId];
    if (userName) {
      setAuth({ userId: normalizedId, userName });
      return true;
    }
    return false;
  }, []);

  const logout = useCallback(() => {
    setAuth(null);
  }, []);

  const addUser = useCallback((userId: string, userName: string): boolean => {
    const normalizedId = userId.trim().toUpperCase();
    if (!normalizedId || !userName.trim() || VALID_USERS[normalizedId]) return false;
    VALID_USERS[normalizedId] = userName.trim();
    try {
      const base = decodeUserTable();
      const extra: Record<string, string> = {};
      for (const [k, v] of Object.entries(VALID_USERS)) {
        if (!base[k]) extra[k] = v;
      }
      localStorage.setItem('turtle_users_extra', JSON.stringify(extra));
    } catch { /* ignore */ }
    return true;
  }, []);

  const listUsers = useCallback((): Array<{ userId: string; userName: string }> => {
    return Object.entries(VALID_USERS).map(([userId, userName]) => ({ userId, userName }));
  }, []);

  const value: AuthContextType = {
    isAuthenticated: auth !== null,
    userId: auth?.userId ?? null,
    userName: auth?.userName ?? '',
    login,
    logout,
    addUser,
    listUsers,
  };

  return (
    <AuthContext.Provider value={value}>
      {children}
    </AuthContext.Provider>
  );
}

export function useAuth(): AuthContextType {
  return useContext(AuthContext);
}
"""

let render() = file
