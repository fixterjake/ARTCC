import { getToken } from "@/services/AuthService";
import Link from "next/link";
import Image from "next/image";
import { Fragment, useEffect } from "react";
import navImage from "../../../public/images/nav.png";
import { Menu, Transition } from "@headlessui/react";
import { useAuthContext } from "@/contexts/AuthContext";

const Navigation = () => {

    const [loggedIn, setLoggedIn, user] = useAuthContext();

    useEffect(() => {
        if (getToken())
            setLoggedIn(true);
    }, [setLoggedIn]);

    return (
        <>
            <nav className="py-6 text-white bg-gray-800">
                <div className="mx-[10%] flex justify-between items-center">
                    <div className="flex items-center">
                        <Link href="/" className="mr-4">
                            <Image src={navImage} width={125} alt="ARTCC" className="pb-4 brightness-0 invert" />
                        </Link>
                        <div>
                            <Menu>
                                <Menu.Button className="mx-4 text-xl font-bold text-white">
                                    About
                                </Menu.Button>
                                <Transition
                                    as={Fragment}
                                    enter="transition ease-out duration-100"
                                    enterFrom="transform opacity-0 scale-95"
                                    enterTo="transform opacity-100 scale-100"
                                    leave="transition ease-in duration-75"
                                    leaveFrom="transform opacity-100 scale-100"
                                    leaveTo="transform opacity-0 scale-95"
                                >
                                    <Menu.Items className="absolute mt-4 bg-gray-600 rounded-md">
                                        <div className="text-lg min-w-[9rem]">
                                            <Menu.Item>
                                                <Link href="/about/staff" className="block p-2 mb-1 rounded-md hover:bg-gray-500">Staff</Link>
                                            </Menu.Item>
                                            <Menu.Item>
                                                <Link href="/about/roster" className="block p-2 mb-1 rounded-md hover:bg-gray-500">Roster</Link>
                                            </Menu.Item>
                                            <Menu.Item>
                                                <Link href="/about/news" className="block p-2 mb-1 rounded-md hover:bg-gray-500">News</Link>
                                            </Menu.Item>
                                            <Menu.Item>
                                                <Link href="/about/faq" className="block p-2 rounded-md hover:bg-gray-500">FAQ</Link>
                                            </Menu.Item>
                                            <Menu.Item>
                                                <Link href="/about/privacy" className="block p-2 rounded-md hover:bg-gray-500">Privacy Policy</Link>
                                            </Menu.Item>
                                        </div>
                                    </Menu.Items>
                                </Transition>
                            </Menu>
                        </div>
                        <div>
                            <Menu>
                                <Menu.Button className="mx-4 text-xl font-bold text-white">
                                    Pilots
                                </Menu.Button>
                                <Transition
                                    as={Fragment}
                                    enter="transition ease-out duration-100"
                                    enterFrom="transform opacity-0 scale-95"
                                    enterTo="transform opacity-100 scale-100"
                                    leave="transition ease-in duration-75"
                                    leaveFrom="transform opacity-100 scale-100"
                                    leaveTo="transform opacity-0 scale-95"
                                >
                                    <Menu.Items className="absolute mt-4 bg-gray-600 rounded-md">
                                        <div className="text-lg min-w-[9rem]">
                                            <Menu.Item>
                                                <Link href="/pilots/feedback" className="block p-2 mb-1 rounded-md hover:bg-gray-500">Feedback</Link>
                                            </Menu.Item>
                                            <Menu.Item>
                                                <Link href="/pilots/airports" className="block p-2 rounded-md hover:bg-gray-500">Airports</Link>
                                            </Menu.Item>
                                        </div>
                                    </Menu.Items>
                                </Transition>
                            </Menu>
                        </div>
                        <div>
                            <Menu>
                                <Menu.Button className="mx-4 text-xl font-bold text-white">
                                    Controllers
                                </Menu.Button>
                                <Transition
                                    as={Fragment}
                                    enter="transition ease-out duration-100"
                                    enterFrom="transform opacity-0 scale-95"
                                    enterTo="transform opacity-100 scale-100"
                                    leave="transition ease-in duration-75"
                                    leaveFrom="transform opacity-100 scale-100"
                                    leaveTo="transform opacity-0 scale-95"
                                >
                                    <Menu.Items className="absolute mt-4 bg-gray-600 rounded-md">
                                        <div className="text-lg min-w-[9rem]">
                                            <Menu.Item>
                                                <Link href="/controllers/events" className="block p-2 rounded-md hover:bg-gray-500">Events</Link>
                                            </Menu.Item>
                                            <Menu.Item>
                                                <Link href="/controllers/visit" className="block p-2 rounded-md hover:bg-gray-500">Apply to Visit</Link>
                                            </Menu.Item>
                                            {loggedIn ? (
                                                <Menu.Item>
                                                    <Link href="/controllers/trainingrequest" className="block p-2 rounded-md hover:bg-gray-500">Request Training</Link>
                                                </Menu.Item>
                                            ) : (<></>)}
                                        </div>
                                    </Menu.Items>
                                </Transition>
                            </Menu>
                        </div>
                        {
                            loggedIn && user.permissions.includes("VIEW.TRAINING.MANAGEMENT") ? (
                                <Menu>
                                    <Menu.Button className="mx-4 text-xl font-bold text-white">
                                        Training Management
                                    </Menu.Button>
                                </Menu>
                            ) : (<></>)
                        }
                        {
                            loggedIn && user.permissions.includes("VIEW.ARTCC.MANAGEMENT") ? (
                                <Menu>
                                    <Menu.Button className="mx-4 text-xl font-bold text-white">
                                        ARTCC Management
                                    </Menu.Button>
                                </Menu>
                            ) : (<></>)
                        }
                    </div>
                    <div className="flex items-center">
                        {loggedIn ? (
                            <div>
                                <Menu>
                                    <Menu.Button className="mx-4 text-xl font-bold text-white">
                                        {user.firstName} {user.lastName}
                                    </Menu.Button>
                                    <Transition
                                        as={Fragment}
                                        enter="transition ease-out duration-100"
                                        enterFrom="transform opacity-0 scale-95"
                                        enterTo="transform opacity-100 scale-100"
                                        leave="transition ease-in duration-75"
                                        leaveFrom="transform opacity-100 scale-100"
                                        leaveTo="transform opacity-0 scale-95"
                                    >
                                        <Menu.Items className="absolute mt-2 bg-gray-600 rounded-md">
                                            <div className="text-lg min-w-[9rem]">
                                                <Menu.Item>
                                                    <Link href="/user/profile" className="block p-2 mb-1 rounded-md hover:bg-gray-500">Profile</Link>
                                                </Menu.Item>
                                                <Menu.Item>
                                                    <Link href="/auth/logout" className="block p-2 rounded-md hover:bg-gray-500">Logout</Link>
                                                </Menu.Item>
                                            </div>
                                        </Menu.Items>
                                    </Transition>
                                </Menu>
                            </div>
                        ) : (
                            <Link href="/login" className="text-xl font-bold text-white">Login</Link>
                        )}
                    </div>
                </div>
            </nav>
        </>
    );
};

export default Navigation;