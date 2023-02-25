import { User } from "@/models/Auth";
import { getUser } from "@/services/AuthService";
import { createContext, useContext, useEffect, useState } from "react";

type AuthContextProps = {
    children: React.ReactNode;
}

// eslint-disable-next-line @typescript-eslint/no-empty-function
const AuthContext = createContext([false, () => {}, {} as User] as [boolean, React.Dispatch<React.SetStateAction<boolean>>, User]);

export function AuthProvidor({ children }: AuthContextProps) {
    const [loggedIn, setLoggedIn] = useState(false);
    const [user, setUser] = useState<User>({} as User);

    useEffect(() => {
        setUser(getUser() || {} as User);
    }, []);

    return (
        <AuthContext.Provider value={[loggedIn, setLoggedIn, user]}>
            {children}
        </AuthContext.Provider>
    );
}

export function useAuthContext() {
    return useContext(AuthContext);
}