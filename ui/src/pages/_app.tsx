import Navigation from "@/components/shared/Navigation";
import type { AppProps } from "next/app";
import "@/styles/theme.scss";
import Container from "@/components/shared/Container";
import { LoginProvidor } from "@/contexts/AuthContext";

export default function App({ Component, pageProps }: AppProps) {
    return (
        <>
            <LoginProvidor>
                <Navigation />
                <Container>
                    <Component {...pageProps} />
                </Container>
            </LoginProvidor>
        </>
    );
}
