import { createContext, useContext, useState } from "react";

type AuthContextProps = {
    children: React.ReactNode;
}

// eslint-disable-next-line @typescript-eslint/no-empty-function
const AuthContext = createContext([false, () => {}] as [boolean, React.Dispatch<React.SetStateAction<boolean>>]);

export function LoginProvidor({ children }: AuthContextProps) {
    const [loggedIn, setLoggedIn] = useState(false);
    return (
        <AuthContext.Provider value={[loggedIn, setLoggedIn]}>
            {children}
        </AuthContext.Provider>
    );
}

export function useAuthContext() {
    return useContext(AuthContext);
}