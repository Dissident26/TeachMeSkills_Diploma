import React, {
  createContext,
  ReactNode,
  useContext,
  useState,
  Dispatch,
  SetStateAction,
} from "react";
import { UserDto } from "../api";

interface UserProviderProps {
  children: ReactNode;
}

interface UserContextProps {
  user?: UserDto;
  setUser: Dispatch<SetStateAction<UserDto>>;
}

const UserContext = createContext<UserContextProps>(null);

export const UserProvider = ({ children }: UserProviderProps) => {
  const [user, setUser] = useState<UserDto>(null);

  return (
    <UserContext.Provider value={{ user, setUser }}>
      {children}
    </UserContext.Provider>
  );
};

export const useUserProvider = (): UserContextProps => {
  const { user, setUser } = useContext(UserContext);
  return { user, setUser };
};
