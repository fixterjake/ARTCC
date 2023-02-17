import { Menu } from "@headlessui/react";
import Link from "next/link";
import Image from "next/image";
import navLogo from "@/public/images/nav.png";

const Header = () => {
    return (
        <div className="bg-gray-800">
            <div className="flex flex-row items-center xl:mr-56 xl:ml-56 lg:mr-28 lg:ml-28 md:mr-12 md:ml-12 mr-4 ml-4 h-24 w-full text-lg font-bold text-white">
                <div className="mr-4">
                    <Link href={"/"}>
                        <Image src={navLogo} alt="Memphis ARTCC" width={180} className="mb-4" />
                    </Link> 
                </div>
                <div className="mx-4">
                    <Menu>
                        <Menu.Button>Controller Resources</Menu.Button>
                    </Menu>
                </div>
                <div className="mx-4">
                    <Menu>
                        <Menu.Button>Pilot Resources</Menu.Button>
                    </Menu>
                </div>
                <div className="mx-4">
                    <Menu>
                        <Menu.Button>Training Management</Menu.Button>
                    </Menu>
                </div>
                <div className="mx-4">
                    <Menu>
                        <Menu.Button>ARTCC Management</Menu.Button>
                    </Menu>
                </div>
                <div className="mx-4 content-end">
                    <Menu>
                        <Menu.Button>Login</Menu.Button>
                    </Menu>
                </div>
            </div>
        </div>
    );
};

export default Header;