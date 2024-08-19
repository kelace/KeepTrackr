import { Build } from '@mui/icons-material';
import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import { AxiosError } from 'axios';
import httpClient from '../../../app/httpClient';
import { useSelector } from 'react-redux';

interface Board {
    id: string | undefined,
    title: string,
    order: number
};

interface Card {
    id?: string | undefined,
    title: string,
    order: number,
    boardId: string
}

interface AddCardRequest {
    title: string,
    order: number,
    boardId: string,
    companyName: string | undefined
}

interface ReorderBoard {
    boardid: string,
    sourceOrder: number,
    destinationOrder: number,
    company: string | undefined
};

interface ReorderCard{
    boardId: string,
    cardId: string,
    sourceOrder: number,
    destinationOrder: number,
    company: string | undefined
};

export const changeCompletionDate = createAsyncThunk('tasks/changeCompletionDate', async (card: { cardId: string, completionDate: Date}) => {


    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };

    const result = await httpClient.put('api/tasks/card', card, config);

    return card;

});

export const createLabel = createAsyncThunk('tasks/createLabel', async (label: { title: string, color: string, cardId: string }) => {

    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };

    const result = await httpClient.post('api/tasks/cards/labels', label, config);

    return label;

});

export const reorderCard = createAsyncThunk('tasks/reorderCard', async (board: ReorderCard) => {

    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };

    /*    const boards = useSelector((x : any) => x.state.boards.entities);*/
    const result = httpClient.put('api/tasks/boards/cards', board, config);

    return board;

});

export const addTask = createAsyncThunk('tasks/addTask', async (task: { taskName: string, cardId: string }) => {

    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };

    const result = httpClient.post('api/card/tasks', task, config);

    return task;

});


export const reorderBoard = createAsyncThunk('tasks/reorderBoard', async (board: ReorderBoard) => {

    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };

/*    const boards = useSelector((x : any) => x.state.boards.entities);*/
    const result = httpClient.put('api/tasks/boards/order', board, config);

    return board;

});

export const addCard = createAsyncThunk('tasks/addCard', async (card: AddCardRequest,) => {

    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };

    const result = await httpClient.post('api/tasks/boards/cards', card, config);

    return result.data;


});

export const addBoard = createAsyncThunk('tasks/addBoard', async (board: any, { rejectWithValue }) => {

    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        }
    };
    try {
        httpClient.post('api/tasks/boards', { title: board.title, order: board.order, companyName: board.company } , config);
        return board;
    } catch (e : any) {
        //const error = e as AxiosError<Board>;

        //if (e.code == '409') return rejectWithValue(e.response.data);

        return rejectWithValue(e.message);
    }    
});

export const fetchAllBoards = createAsyncThunk('tasks/fetchBoards', async (company: string | undefined) => {

    const token = localStorage.getItem('token');

    const config = {
        headers: {
            Authorization: `Bearer ${token}`
        },
        params: {
            company
        }
    };

    const result = await httpClient.get('api/tasks/boards', config);

    return result.data;
});

//const getAllTasksSelector = (state: any) => {
//    return state.tasks.boards.forEach
//};

export interface TaskPagwState {

};

const initialState = {

    openedCalendar: false,
    labelShow: false,
    openedAssign: false,
    openedCardId: '',
    color: '#ffff',
    openedLabelModal: false,
    newLabelName: '',

    newBoard: {
        title:''
    },

    boards: {
        ids: [],
        entities: []
    },

    cards: {
        ids: [],
        entities: []
    },

    labels: {
        entities: []
    },
    users: {
        entities:[]
    }

};

const slice = createSlice({
    name: 'tasks',
    reducers: {
        changeNewBoardName: (state : any, action : any) => {
            state.newBoard = action.payload;
        },

        openCard: (state: any, action: any) => {
            state.openedCardId = action.payload
        },

        openLabel: (state: any) => {
            state.labelShow = true;
        },

        closeLabel: (state: any) => {
            state.openedLabelModal = false;
        },

        changeColor: (state: any, action: any) => {
            state.color = action.payload;
        },
        changeNewLabelName: (state: any, action: any) => {
            state.newLabelName = action.payload;
        },
        createLabel: (state: any) => {
            state.labels.entities.push({
                title: state.newLabelName
            })
        },
        openCalendar: (state: any) => {
            state.openedCalendar = true;
        },
        closeCalendar: (state: any) => {
        state.openedCalendar = true;
    }
    },

    initialState: initialState,
    extraReducers(builder) {
        builder.addCase(fetchAllBoards.fulfilled, (state: any, action: any) => {
            state.boards.entities = action.payload.boards;
            state.cards.entities = action.payload.cards;
            state.labels.entities = action.payload.labels;
        });

        builder.addCase(reorderBoard.fulfilled, (state: any, action: any) => {
            const board = state.boards.entities.find((el: any) => el.id == action.payload.boardid);

            board.order = action.payload.destinationOrder;

           /* state.boards.entities[action.payload.id].order = */
            state.boards.entities.sort((a: any, b: any) => a.order > b.order ? 1 : -1);
        });

        builder.addCase(addBoard.fulfilled, (state: any, action: any) => {
            state.boards.entities.push(action.payload);
        });

        builder.addCase(addBoard.rejected, (state: any, action: any) => {
            state.boards = state.boards.filter((value: any, index: any, arr: any) => {
                if (value.order != action.payload.order && value.name != action.payload.name) {
                    return true;
                }
                return false;
            });
        });

        builder.addCase(addCard.fulfilled, (state: any, action: any) => {
            state.cards.entities.push(action.payload);
        });

        builder.addCase(reorderCard.fulfilled, (state: any, action: any) => {

            const cards = state.cards.entities.find((el: any) => el.id == action.payload.boardid);

            cards.order = action.payload.destinationOrder;

            state.cards.entities.sort((a: any, b: any) => a.order > b.order ? 1 : -1);

        });

        builder.addCase(createLabel.fulfilled, (state: any, action: any) => {
            state.labels.entities.push(action.payload);
        });

        builder.addCase(changeCompletionDate.pending, (state: any, action: any) => {

            state.openedCalendar = false;

        });

        builder.addCase(changeCompletionDate.fulfilled, (state: any, action: any) => {



        });
    }
});

export const { changeNewBoardName, openCard, openLabel, closeLabel, changeColor, changeNewLabelName, openCalendar } = slice.actions;

export default slice.reducer;